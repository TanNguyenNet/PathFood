using AutoMapper;
using AutoMapper.QueryableExtensions;
using CV.Core.Data;
using CV.Data.Entities.Blog;
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

        public PagedResult<PostModel> GetAll(int page = 1, int pageSize = 20, string filter = "", DateTimeOffset? fromDate = null, DateTimeOffset? toDate = null)
        {
            var query = _postRepo.TableNoTracking;

            if (!string.IsNullOrWhiteSpace(filter))
                query = query.Where(x => x.Name.Contains(filter));

            if (fromDate != null)
                query = query.Where(x => x.PushlishDate >= fromDate.Value);

            if (toDate != null)
                query = query.Where(x => x.PushlishDate <= toDate.Value);

            query = query.OrderByDescending(x => x.PushlishDate)
               .Skip((page - 1) * pageSize).Take(pageSize);

            var paginationSet = new PagedResult<PostModel>()
            {
                Results = query.ProjectTo<PostModel>(_mapper.ConfigurationProvider).ToList(),
                CurrentPage = page,
                RowCount = query.Count(),
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
            var query = _postRepo.TableNoTracking.Where(x=>x.Slug== slug);

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
