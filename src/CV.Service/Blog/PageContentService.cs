using AutoMapper;
using AutoMapper.QueryableExtensions;
using CV.Core.Data;
using CV.Data.Entities.Blog;
using CV.Data.Model.Blog;
using CV.Service.Interface.Blog;
using CV.Utils.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CV.Service.Blog
{
    public class PageContentService : IPageContentService
    {

        private readonly IMapper _mapper;
        private readonly IRepository<PageContent> _pageContentRepo;
        private readonly IUnitOfWork _uow;

        public PageContentService(IMapper mapper,IUnitOfWork uow)
        {
            _mapper = mapper;
            _uow = uow;
            _pageContentRepo = _uow.GetRepository<PageContent>();
        }

        public void Delete(string userCurrent, string pageId)
        {
            try
            {
                var entity = _pageContentRepo.GetById(pageId);
                entity.DeletedTime = CoreHelper.SystemTimeNowUTCTimeZoneLocal;
                entity.DeletedBy = userCurrent;

                _pageContentRepo.Update(entity);

            }
            catch
            {

                throw;
            }
        }

        public IEnumerable<PageContentModel> GetAll(bool? home = null)
        {
            var query = _pageContentRepo.TableNoTracking;

            if (home != null)
                query = query.Where(x => x.Home == home.Value);

            return query.ProjectTo<PageContentModel>(_mapper.ConfigurationProvider).ToList();
        }

        public PageContentModel GetPage(string id)
        {
            var query = _pageContentRepo.GetById(id);
            return _mapper.Map<PageContentModel>(query);
        }

        public PageContentModel GetPageSlug(string slug)
        {
            try
            {
                var query = _pageContentRepo.TableNoTracking.Where(x => x.Slug == slug).FirstOrDefault();

                return _mapper.Map<PageContentModel>(slug);
            }
            catch
            {
                throw;
            }
        }

        public PageContentModel Insert(string userCurrent, PageContentModel pageContent)
        {
            try
            {
                var newPageContent = _mapper.Map<PageContent>(pageContent);

                newPageContent.CreatedBy = userCurrent;
                newPageContent.Slug = StringHelper.ToUrlFriendlyWithDate(newPageContent.Name);

                _pageContentRepo.Insert(newPageContent);

                return pageContent;
            }
            catch
            {

                throw;
            }
        }

        public PageContentModel Update(string userCurrent, string pageId, PageContentModel pageContent)
        {
            try
            {
                var updatePageContent = _pageContentRepo.GetById(pageId);

                _mapper.Map(pageContent, updatePageContent);

                updatePageContent.LastUpdatedBy = userCurrent;

                return pageContent;

            }
            catch
            {
                throw;
            }
        }
    }
}
