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
    public class CatalogFunctionService : ICatalogFunctionService
    {
        private readonly IMapper _mapper;
        private readonly IRepository<CatalogFunction> _catalogFunctionRepo;
        private readonly IRepository<SearchPage> _searchPageRepo;
        private readonly IUnitOfWork _uow;

        public CatalogFunctionService(IMapper mapper, IUnitOfWork uow)
        {
            _mapper = mapper;
            _uow = uow;
            _catalogFunctionRepo = _uow.GetRepository<CatalogFunction>();
            _searchPageRepo = _uow.GetRepository<SearchPage>();
        }

        public void Delete(string id, string userId)
        {
            try
            {
                var cat = _catalogFunctionRepo.GetById(id);
                cat.DeletedBy = userId;
                cat.DeletedTime = CoreHelper.SystemTimeNowUTCTimeZoneLocal;
                _catalogFunctionRepo.Update(cat);

                var searchPage = _searchPageRepo.TableNoTracking.FirstOrDefault(x => x.ItemId == id);

                if (searchPage != null)
                    _searchPageRepo.Delete(searchPage);

            }
            catch
            {
                throw;
            }
        }

        public IEnumerable<CatalogFunctionModel> GetAll(Languages? lang, bool active = false, bool getProduct = false)
        {
            var query = _catalogFunctionRepo.TableNoTracking;

            if (active)
                query = query.Where(x => x.Active == active);

            if (lang != null)
                query = query.Where(x => x.Lang == lang.Value);

            if (getProduct)
                query = query.Include(x => x.Product).Where(x => x.Product.Any(p => p.New == true));

            query = query.OrderBy(x => x.Name);

            return query.ProjectTo<CatalogFunctionModel>(_mapper.ConfigurationProvider).ToList();
        }

        public CatalogFunctionModel GetCatalogFunction(string id)
        {
            var query = _catalogFunctionRepo.GetById(id);

            return _mapper.Map<CatalogFunctionModel>(query);
        }

        public CatalogFunctionModel Insert(string userCurrentId, CatalogFunctionModel catalogFunction)
        {
            try
            {
                var newCat = _mapper.Map<CatalogFunction>(catalogFunction);

                newCat.CreatedBy = userCurrentId;
                newCat.Slug = StringHelper.ToUrlFriendly(catalogFunction.Name);

                _catalogFunctionRepo.Insert(newCat);

                var newSearchPage = new SearchPage();
                newSearchPage.Lang = newCat.Lang;
                newSearchPage.Name = newCat.Name;
                newSearchPage.Slug = newCat.Slug;
                newSearchPage.ItemId = newCat.Id;

                if (newCat.Lang == Languages.Vi)
                    newSearchPage.URL = CatalogEndpoints.FunctionEndpoint.Replace("{function}", newSearchPage.Slug);
                else
                    newSearchPage.URL = CatalogEndpoints.EnglishFunctionEndpoint.Replace("{function}", newSearchPage.Slug);

                _searchPageRepo.Insert(newSearchPage);

                return catalogFunction;
            }
            catch
            {
                throw;
            }
        }

        public CatalogFunctionModel Update(string catId, string userCurrentId, CatalogFunctionModel catalogFunction)
        {
            try
            {
                var updateCat = _catalogFunctionRepo.GetById(catId);

                _mapper.Map(catalogFunction, updateCat);

                updateCat.LastUpdatedBy = userCurrentId;
                updateCat.Slug = StringHelper.ToUrlFriendly(catalogFunction.Name);

                _catalogFunctionRepo.Update(updateCat);

                var updateSearch = _searchPageRepo.TableNoTracking.FirstOrDefault(x => x.ItemId == catId);

                if (updateSearch != null)
                    updateSearch.Slug = updateCat.Slug;

                if (updateCat.Lang == Languages.Vi)
                    updateSearch.URL = CatalogEndpoints.FunctionEndpoint.Replace("{function}", updateSearch.Slug);
                else
                    updateSearch.URL = CatalogEndpoints.EnglishFunctionEndpoint.Replace("{function}", updateSearch.Slug);

                _searchPageRepo.Update(updateSearch);

                return catalogFunction;
            }
            catch
            {
                throw;
            }
        }
    }
}
