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
    public class WebImageService : IWebImageService
    {
        private readonly IMapper _mapper;
        private readonly IRepository<WebImage> _webImageRepo;
        private readonly IUnitOfWork _uow;

        public WebImageService(IMapper mapper, IUnitOfWork uow)
        {
            _mapper = mapper;
            _uow = uow;
            _webImageRepo = _uow.GetRepository<WebImage>();
        }

        public void Delete(string userCurrent, string imageId)
        {
            try
            {
                var model = _webImageRepo.GetById(imageId);
                model.DeletedBy = userCurrent;
                model.DeletedTime = CoreHelper.SystemTimeNowUTCTimeZoneLocal;
                _webImageRepo.Update(model);
            }
            catch
            {

                throw;
            }
        }

        public IEnumerable<WebImageModel> GetAll()
        {
            var query = _webImageRepo.TableNoTracking;

            return query.ProjectTo<WebImageModel>(_mapper.ConfigurationProvider).ToList();
        }

        public IEnumerable<dynamic> GetAllPosition()
        {
            var list = EnumHelper.ToDictionary(typeof(Position)).Select(x => new { Id = x.Key, Name = x.Value });
            return list;
        }

        public WebImageModel GetImage(string id)
        {
            var query = _webImageRepo.GetById(id);
            return _mapper.Map<WebImageModel>(query);
        }

    public WebImageModel Insert(string userCurrent, WebImageModel webImage)
        {
            try
            {
                var newImage = _mapper.Map<WebImage>(webImage);
                newImage.CreatedBy = userCurrent;
                _webImageRepo.Insert(newImage);
                return webImage;
            }
            catch
            {

                throw;
            }
        }

        public WebImageModel Update(string userCurrent, string imageId, WebImageModel webImage)
        {
            try
            {
                var updateImage = _webImageRepo.GetById(imageId);
                _mapper.Map(webImage, updateImage);

                updateImage.LastUpdatedBy = userCurrent;

                _webImageRepo.Update(updateImage);

                return webImage;
            }
            catch
            {

                throw;
            }
        }
    }
}
