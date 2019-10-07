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
    public class CatalogSectorService : ICatalogSectorService
    {

        private readonly IMapper _mapper;
        private readonly IRepository<CatalogSector> _catalogSectorRepo;
        private readonly IUnitOfWork _uow;

        public CatalogSectorService(IMapper mapper, IUnitOfWork uow)
        {
            _mapper = mapper;
            _uow = uow;
            _catalogSectorRepo = _uow.GetRepository<CatalogSector>();
        }

        public void Delete(string id, string userId)
        {
            try
            {
                var catalog = _catalogSectorRepo.GetById(id);
                catalog.DeletedBy = userId;
                catalog.DeletedTime = CoreHelper.SystemTimeNowUTCTimeZoneLocal;
                _catalogSectorRepo.Update(catalog);
            }
            catch
            {
                throw;
            }
        }

        public IEnumerable<CatalogSectorModel> GetAll(Languages? lang)
        {
            var query = _catalogSectorRepo.TableNoTracking;

            if (lang != null)
                query = query.Where(x=>x.Lang == lang.Value);

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

                return catalogSector;

            }
            catch
            {

                throw;
            }
            throw new NotImplementedException();
        }

        public CatalogSectorModel Update(string catId, string userCurrentId, CatalogSectorModel catalogSector)
        {
            throw new NotImplementedException();
        }
    }
}
