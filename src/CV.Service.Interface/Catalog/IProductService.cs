using CV.Data.Enum;
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

        IEnumerable<ProductModel> GetProductByFunction(string slug);

        IEnumerable<ProductModel> GetProductBySector(string slug);

        PagedResult<ProductModel> GetPagedAll(int page = 1, int pageSize = 20, string filter = "", string functionId = "", string sectorId = "", Languages? lang = null,bool include= false);

        IEnumerable<ProductModel> GetAll(Languages? lang = null);

        ProductModel Insert(string userCurrent, ProductModel product);

        ProductModel Update(string id, string userCurrentId, ProductModel product);

        void Delete(string id, string userId);
    }
}
