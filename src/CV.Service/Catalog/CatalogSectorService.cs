using AutoMapper;
using AutoMapper.QueryableExtensions;
using CV.Core.Data;
using CV.Core.Endpoints;
using CV.Data.Entities.Catalog;
using CV.Data.Entities.Setting;
using CV.Data.Enum;
using CV.Data.Model.Catalog;
using CV.Service.Interface.Catalog;
using CV.Utils.Helper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CV.Service.Catalog
{
    public class CatalogSectorService : ICatalogSectorService
    {

        private readonly IMapper _mapper;
        private readonly IRepository<CatalogSector> _catalogSectorRepo;
        private readonly IRepository<SearchPage> _searchPageRepo;
        private readonly IUnitOfWork _uow;

        public CatalogSectorService(IMapper mapper, IUnitOfWork uow)
        {
            _mapper = mapper;
            _uow = uow;
            _catalogSectorRepo = _uow.GetRepository<CatalogSector>();
            _searchPageRepo = _uow.GetRepository<SearchPage>();
        }

        public void Delete(string id, string userId)
        {
            try
            {
                var catalog = _catalogSectorRepo.GetById(id);
                catalog.DeletedBy = userId;
                catalog.DeletedTime = CoreHelper.SystemTimeNowUTCTimeZoneLocal;
                _catalogSectorRepo.Update(catalog);

                var searchPage = _searchPageRepo.TableNoTracking.FirstOrDefault(x => x.ItemId == id);

                if (searchPage != null)
                    _searchPageRepo.Delete(searchPage);
            }
            catch
            {
                throw;
            }
        }

        public IEnumerable<CatalogSectorModel> GetAll(Languages? lang, bool active = false, bool getProduct = false)
        {
            var query = _catalogSectorRepo.TableNoTracking;

            if (active)
                query = query.Where(x => x.Active == active);

            if (lang != null)
                query = query.Where(x => x.Lang == lang.Value);
            if (getProduct)
            {
                query = query.Include(x => x.Product).Where(x => x.Product.Any(p => p.New == true));
            }
                
            return query.ProjectTo<CatalogSectorModel>(_mapper.ConfigurationProvider).ToList();
        }

        public CatalogSectorModel GetCatalogSector(string id)
        {
            var query = _catalogSectorRepo.GetById(id);
            return _mapper.Map<CatalogSectorModel>(query);
        }

        public CatalogSectorModel Insert(string userCurrentId, CatalogSectorModel catalogSector)
        {
            try
            {
                var newCatalog = _mapper.Map<CatalogSector>(catalogSector);

                newCatalog.CreatedBy = userCurrentId;
                newCatalog.Slug = StringHelper.ToUrlFriendly(newCatalog.Name);
                _catalogSectorRepo.Insert(newCatalog);

                var newSearchPage = new SearchPage();
                newSearchPage.Lang = newCatalog.Lang;
                newSearchPage.Name = newCatalog.Name;
                newSearchPage.Slug = newCatalog.Slug;
                newSearchPage.ItemId = newCatalog.Id;

                if (newCatalog.Lang == Languages.Vi)
                    newSearchPage.URL = CatalogEndpoints.SectorEndpoint.Replace("{function}", newSearchPage.Slug);
                else
                    newSearchPage.URL = CatalogEndpoints.EnglishSectorEndpoint.Replace("{function}", newSearchPage.Slug);

                _searchPageRepo.Insert(newSearchPage);

                return catalogSector;
            }
            catch
            {
                throw;
            }
        }

        public CatalogSectorModel Update(string catId, string userCurrentId, CatalogSectorModel catalogSector)
        {
            try
            {
                var updateCatalogSector = _catalogSectorRepo.GetById(catId);

                _mapper.Map(catalogSector, updateCatalogSector);

                updateCatalogSector.LastUpdatedBy = userCurrentId;
                _catalogSectorRepo.Update(updateCatalogSector);

                var updateSearch = _searchPageRepo.TableNoTracking.FirstOrDefault(x => x.ItemId == catId);

                if (updateSearch != null)
                    updateSearch.Slug = updateCatalogSector.Slug;

                if (updateCatalogSector.Lang == Languages.Vi)
                    updateSearch.URL = CatalogEndpoints.FunctionEndpoint.Replace("{function}", updateSearch.Slug);
                else
                    updateSearch.URL = CatalogEndpoints.EnglishFunctionEndpoint.Replace("{function}", updateSearch.Slug);

                _searchPageRepo.Update(updateSearch);

                return catalogSector;
            }
            catch
            {
                throw;
            }
        }
    }
}
