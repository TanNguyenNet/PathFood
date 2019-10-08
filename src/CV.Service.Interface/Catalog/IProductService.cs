using CV.Data.Model.Catalog;
using CV.Utils.Utils.Web.Page;
using System;
using System.Collections.Generic;
using System.Text;

namespace CV.Service.Interface.Catalog
{
    public interface IProductService
    {
        ProductModel GetProduct(string id);

        ProductModel GetProductByFunction(string slug);

        ProductModel GetProductBySector(string slug);

        PagedResult<ProductModel> GetAll(int page = 1, int pageSize = 20, string filter = "", string functionId = "", string sectorId = "");

        ProductModel Insert(string userCurrent, ProductModel product);

        ProductModel Update(string id, string userCurrentId, ProductModel product);

        void Delete(string id, string userId);
    }
}
