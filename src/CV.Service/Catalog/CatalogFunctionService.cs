using AutoMapper;
using AutoMapper.QueryableExtensions;
using CV.Core.Data;
using CV.Data.Entities.Catalog;
using CV.Data.Enum;
using CV.Data.Model.Catalog;
using CV.Service.Interface.Catalog;
using CV.Utils.Helper;
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
        private readonly IUnitOfWork _uow;

        public CatalogFunctionService(IMapper mapper, IUnitOfWork uow)
        {
            _mapper = mapper;
            _uow = uow;
            _catalogFunctionRepo = _uow.GetRepository<CatalogFunction>();
        }

        public void Delete(string id, string userId)
        {
            try
            {
                var cat = _catalogFunctionRepo.GetById(id);
                cat.DeletedBy = userId;
                cat.DeletedTime = CoreHelper.SystemTimeNowUTCTimeZoneLocal;
                _catalogFunctionRepo.Update(cat);
            }
            catch
            {
                throw;
            }
        }

        public IEnumerable<CatalogFunctionModel> GetAll(Languages? lang)
        {
            var query = _catalogFunctionRepo.TableNoTracking;

            if (lang != null)
                query = query.Where(x => x.Lang == lang.Value);

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

                return catalogFunction;
            }
            catch
            {
                throw;
            }
        }
    }
}
