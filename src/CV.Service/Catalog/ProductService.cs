﻿using AutoMapper;
using AutoMapper.QueryableExtensions;
using CV.Core.Data;
using CV.Data.Entities.Catalog;
using CV.Data.Model.Catalog;
using CV.Service.Interface.Catalog;
using CV.Utils.Helper;
using CV.Utils.Utils.Web.Page;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CV.Service.Catalog
{
    public class ProductService : IProductService
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Product> _productRepo;
        private readonly IUnitOfWork _uow;

        public ProductService(IMapper mapper, IUnitOfWork uow)
        {
            _mapper = mapper;
            _uow = uow;
            _productRepo = _uow.GetRepository<Product>();
        }

        public void Delete(string id, string userId)
        {
            try
            {
                var product = _productRepo.GetById(id);
                product.DeletedBy = userId;
                product.DeletedTime = CoreHelper.SystemTimeNowUTCTimeZoneLocal;
                _productRepo.Update(product);
            }
            catch
            {
                throw;
            }
        }

        public PagedResult<ProductModel> GetAll(int page = 1, int pageSize = 20, string filter = "", string functionId = "", string sectorId = "")
        {
            var query = _productRepo.TableNoTracking;

            if (!string.IsNullOrWhiteSpace(filter))
                query = query.Where(x => x.Name.Contains(filter));

            if (!string.IsNullOrWhiteSpace(functionId))
                query = query.Where(x => x.CatalogFunctionId == functionId);

            if (!string.IsNullOrWhiteSpace(sectorId))
                query = query.Where(x => x.CatalogSectorId == sectorId);

            var paginationSet = new PagedResult<ProductModel>()
            {
                Results = query.ProjectTo<ProductModel>(_mapper.ConfigurationProvider).ToList(),
                CurrentPage = page,
                RowCount = query.Count(),
                PageSize = pageSize
            };
            return paginationSet;
        }

        public ProductModel GetProduct(string id)
        {
            var query = _productRepo.GetById(id);

            return _mapper.Map<ProductModel>(query);
        }

        public ProductModel GetProductByFunction(string slug)
        {
            throw new NotImplementedException();
        }

        public ProductModel GetProductBySector(string slug)
        {
            throw new NotImplementedException();
        }

        public ProductModel Insert(string userCurrent, ProductModel product)
        {
            try
            {
                var newProduct = _mapper.Map<Product>(product);

                newProduct.CreatedBy = userCurrent;

                _productRepo.Insert(newProduct);

                return product;
            }
            catch
            {
                throw;
            }
        }

        public ProductModel Update(string id, string userCurrentId, ProductModel product)
        {
            try
            {
                var updateProduct = _productRepo.GetById(id);

                _mapper.Map(product, updateProduct);

                updateProduct.LastUpdatedBy = userCurrentId;

                _productRepo.Update(updateProduct);

                return product;
            }
            catch
            {
                throw;
            }
        }
    }
}
