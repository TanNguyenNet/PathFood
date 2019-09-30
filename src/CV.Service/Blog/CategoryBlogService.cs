using AutoMapper;
using AutoMapper.QueryableExtensions;
using CV.Core.Data;
using CV.Data.Entities.Blog;
using CV.Data.Enum;
using CV.Data.Model.Blog;
using CV.Service.Interface.Blog;
using CV.Utils.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CV.Service.Blog
{
    public class CategoryBlogService : ICategoryBlogService
    {
        private readonly IMapper _mapper;
        private readonly IRepository<CategoryBlog> _categoryBlogRepo;
        private readonly IUnitOfWork _uow;

        public CategoryBlogService(IMapper mapper, IUnitOfWork uow)
        {
            _uow = uow;
            _mapper = mapper;
            _categoryBlogRepo = _uow.GetRepository<CategoryBlog>();
        }

        public IEnumerable<CategoryBlogModel> GetAll(Languages? lang)
        {
            var query = _categoryBlogRepo.TableNoTracking;
            if (lang != null)
                query = query.Where(x => x.Lang == lang.Value);
            return query.ProjectTo<CategoryBlogModel>(_mapper.ConfigurationProvider).ToList();
        }

        public CategoryBlogModel GetCategoryBlog(string id)
        {
            var query = _categoryBlogRepo.GetById(id);
            return _mapper.Map<CategoryBlogModel>(query);
        }

        public CategoryBlogModel Insert(string userCurrentId, CategoryBlogModel category)
        {
            try
            {
                var newCat = _mapper.Map<CategoryBlog>(category);
                newCat.CreatedBy = userCurrentId;
                newCat.Slug = StringHelper.ToUrlFriendly(newCat.Name);
                _categoryBlogRepo.Insert(newCat);
                return category;
            }
            catch
            {
                throw;
            }
        }

        public CategoryBlogModel Update(string catId, string userCurrentId, CategoryBlogModel category)
        {
            try
            {
                var updateCat = _categoryBlogRepo.GetById(catId);

                _mapper.Map(category, updateCat);
                updateCat.LastUpdatedBy = userCurrentId;
                _categoryBlogRepo.Update(updateCat);
                return category;
            }
            catch
            {

                throw;
            }
        }
    }
}
