using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CV.Data.Model.Catalog;
using CV.Service.Interface.Catalog;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CV.Web.Api.Catalog
{
    public class ProductController : BaseApiController
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        public IActionResult Get(int page = 1, int pageSize = 20, string filter = "")
        {
            var model = _productService.GetPagedAll(page, pageSize, filter);
            return Ok(model);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetProduct(string id)
        {
            var model = _productService.GetProduct(id);
            return Ok(model);
        }

        [HttpPost]
        public IActionResult Create(ProductModel productModel)
        {
            if (ModelState.IsValid)
            {
                var newPost = _productService.Insert(base.UserId, productModel);
            }
            return Ok();
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult Update(string id, ProductModel productModel)
        {
            if (ModelState.IsValid)
            {
                var updatePost = _productService.Update(id, base.UserId, productModel);
            }
            return Ok();
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(string id)
        {
            _productService.Delete(id, base.UserId);
            return Ok();
        }
    }
}