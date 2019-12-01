using AutoMapper;
using AutoMapper.QueryableExtensions;
using CV.Core.Data;
using CV.Core.Endpoints;
using CV.Data.Entities.Blog;
using CV.Data.Entities.Setting;
using CV.Data.Enum;
using CV.Data.Model.Blog;
using CV.Service.Interface.Blog;
using CV.Utils.Helper;
using CV.Utils.Utils.Web.Page;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CV.Service.Blog
{
    public class PostService : IPostService
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Post> _postRepo;
        private readonly IRepository<SearchPage> _searchPageRepo;
        private readonly IUnitOfWork _uow;
        public PostService(IMapper mapper, IUnitOfWork uow)
        {
            _mapper = mapper;
            _uow = uow;
            _postRepo = uow.GetRepository<Post>();
            _searchPageRepo = uow.GetRepository<SearchPage>();
        }

        public void Delete(string id, string userId)
        {
            try
            {
                var entity = _postRepo.GetById(id);
                entity.DeletedTime = CoreHelper.SystemTimeNowUTCTimeZoneLocal;
                entity.DeletedBy = userId;
                _postRepo.Update(entity);

                var entitySearchPage = _searchPageRepo.TableNoTracking.Where(x => x.ItemId == id).FirstOrDefault();

                if (entitySearchPage != null)
                    _searchPageRepo.Delete(entitySearchPage);
            }
            catch
            {

                throw;
            }
        }

        public IEnumerable<PostModel> GetAll(Languages? lang = null, int totalPost = 1,
            bool home = false, bool? active = null, bool publishDate = false)
        {
            var query = _postRepo.TableNoTracking;

            if (lang != null)
                query = query.Where(x => x.Lang == lang.Value);

            if (home)
                query = query.Where(x => x.SetHomePage == home);

            if (active != null)
                query = query.Where(x => x.Active == active);

            if (publishDate)
                query = query.Where(x => x.PushlishDate <= CoreHelper.SystemTimeNowUTCTimeZoneLocal.DateTime);

            query = query.OrderByDescending(x => x.PushlishDate).Take(totalPost);

            return query.ProjectTo<PostModel>(_mapper.ConfigurationProvider).ToList();
        }

        public PagedResult<PostModel> GetPagedAll(int page = 1, int pageSize = 20, string filter = "",
            DateTimeOffset? fromDate = null, DateTimeOffset? toDate = null, bool publishDate = false, 
            Languages? lang = null,string cat = "",bool include = false)
        {
            var query = _postRepo.TableNoTracking;

            if (lang != null)
                query = query.Where(x => x.Lang == lang.Value);

            if (!string.IsNullOrWhiteSpace(filter))
                query = query.Where(x => x.Name.Contains(filter));

            if (fromDate != null)
                query = query.Where(x => x.PushlishDate >= fromDate.Value);

            if (toDate != null)
                query = query.Where(x => x.PushlishDate <= toDate.Value);

            if (publishDate)
                query = query.Where(x => x.PushlishDate.Value.DateTime <= CoreHelper.SystemTimeNowUTCTimeZoneLocal.DateTime);

            if (!string.IsNullOrWhiteSpace(cat))
                query = query.Where(x => x.CategoryBlog.Slug == cat);

            if (include)
                query = query.Include(x => x.CategoryBlog);
            var rowCount = query.Count();
            query = query.OrderByDescending(x => x.PushlishDate)
               .Skip((page - 1) * pageSize).Take(pageSize);

            var paginationSet = new PagedResult<PostModel>()
            {
                Results = query.ProjectTo<PostModel>(_mapper.ConfigurationProvider).ToList(),
                CurrentPage = page,
                RowCount = rowCount,
                PageSize = pageSize
            };
            return paginationSet;
        }

        public PostModel GetPost(string id)
        {
            var query = _postRepo.GetById(id);

            return _mapper.Map<PostModel>(query);
        }

        public PostModel GetPostSlug(string slug)
        {
            var query = _postRepo.TableNoTracking.Where(x => x.Slug == slug).FirstOrDefault();

            return _mapper.Map<PostModel>(query);
        }

        public PostModel Insert(string userCurrent, PostModel post)
        {
            try
            {
                var newPost = _mapper.Map<Post>(post);

                newPost.CreatedBy = userCurrent;
                newPost.Slug = StringHelper.ToUrlFriendlyWithDate(newPost.Name);
                _postRepo.Insert(newPost);

                var newSearchPage = new SearchPage();
                newSearchPage.Lang = newPost.Lang;
                newSearchPage.Name = newPost.Name;
                newSearchPage.Slug = newPost.Slug;
                newSearchPage.ItemId = newPost.Id;

                if (newPost.Lang == Languages.Vi)
                    newSearchPage.URL = BlogEndpoints.PostEndpoint.Replace("{slug}", newSearchPage.Slug);
                else
                    newSearchPage.URL = BlogEndpoints.EnglishPostEndpoint.Replace("{slug}", newSearchPage.Slug);

                _searchPageRepo.Insert(newSearchPage);

                return post;
            }
            catch
            {
                throw;
            }
        }

        public PostModel Update(string id, string userCurrentId, PostModel post)
        {
            try
            {
                var updatePost = _postRepo.GetById(id);
                _mapper.Map(post, updatePost);
                updatePost.LastUpdatedBy = userCurrentId;

                _postRepo.Update(updatePost);

                var updateSearch = _searchPageRepo.TableNoTracking.FirstOrDefault(x => x.ItemId == id);

                if (updateSearch != null)
                {
                    updateSearch.Slug = updatePost.Slug;
                    updateSearch.Lang = updatePost.Lang;
                    updateSearch.Name = updatePost.Name;
                }
                    

                if (updatePost.Lang == Languages.Vi)
                    updateSearch.URL = BlogEndpoints.PostEndpoint.Replace("{slug}", updateSearch.Slug);
                else
                    updateSearch.URL = BlogEndpoints.EnglishPostEndpoint.Replace("{slug}", updateSearch.Slug);

                _searchPageRepo.Update(updateSearch);

                return post;
            }
            catch
            {
                throw;
            }
        }
    }
}
