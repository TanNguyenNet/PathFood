﻿using AutoMapper;
using AutoMapper.QueryableExtensions;
using CV.Core.Data;
using CV.Data.Entities.Blog;
using CV.Data.Enum;
using CV.Data.Model.Blog;
using CV.Service.Interface.Blog;
using CV.Utils.Helper;
using CV.Utils.Utils.Web.Page;
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
        private readonly IUnitOfWork _uow;
        public PostService(IMapper mapper, IUnitOfWork uow)
        {
            _mapper = mapper;
            _uow = uow;
            _postRepo = uow.GetRepository<Post>();
        }

        public void Delete(string id, string userId)
        {
            try
            {
                var entity = _postRepo.GetById(id);
                entity.DeletedTime = CoreHelper.SystemTimeNowUTCTimeZoneLocal;
                entity.DeletedBy = userId;
                _postRepo.Update(entity);
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
            Languages? lang = null,string cat = "")
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
                return post;
            }
            catch
            {
                throw;
            }
        }
    }
}
