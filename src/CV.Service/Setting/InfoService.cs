using AutoMapper;
using AutoMapper.QueryableExtensions;
using CV.Core.Data;
using CV.Data.Entities.Setting;
using CV.Data.Enum;
using CV.Data.Model.Setting;
using CV.Service.Interface.Setting;
using CV.Utils.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CV.Service.Setting
{
    public class InfoService : IInfoService
    {

        private readonly IMapper _mapper;
        private readonly IRepository<Info> _infoRepo;
        private readonly IUnitOfWork _uow;

        public InfoService(IMapper mapper, IUnitOfWork uow)
        {
            _mapper = mapper;
            _uow = uow;
            _infoRepo = _uow.GetRepository<Info>();
        }

        public void Delete(string userCurrent, string infoId)
        {
            try
            {
                var entity = _infoRepo.GetById(infoId);

                entity.DeletedBy = userCurrent;
                entity.DeletedTime = CoreHelper.SystemTimeNowUTCTimeZoneLocal;

                _infoRepo.Update(entity);

            }
            catch
            {

                throw;
            }
        }

        public IEnumerable<InfoModel> GetAll(InfoType? type = null)
        {
            var query = _infoRepo.TableNoTracking;

            if (type != null)
                query = query.Where(x => x.InfoType == type.Value);

            return query.ProjectTo<InfoModel>(_mapper.ConfigurationProvider).ToList();
        }

        public IEnumerable<dynamic> GetAllType()
        {
            var list = EnumHelper.ToDictionary(typeof(InfoType)).Select(x => new { Id = x.Key, Name = x.Value });
            return list;
        }

        public InfoModel GetInfo(string id)
        {
            var entity = _infoRepo.GetById(id);
            return _mapper.Map<InfoModel>(entity);
        }

      
        public InfoModel Insert(string userCurrent, InfoModel info)
        {
            try
            {
                var newInfo = _mapper.Map<Info>(info);

                newInfo.CreatedBy = userCurrent;

                _infoRepo.Insert(newInfo);

                return info;
            }
            catch
            {

                throw;
            }
        }

        public InfoModel Update(string userCurrent, string infoId, InfoModel info)
        {
            try
            {
                var updateInfo = _infoRepo.GetById(infoId);

                _mapper.Map(info, updateInfo);

                updateInfo.LastUpdatedBy = userCurrent;

                _infoRepo.Update(updateInfo);

                return info;
            }
            catch
            {
                throw;
            }
        }
    }
}
