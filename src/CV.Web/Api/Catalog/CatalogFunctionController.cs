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
    public class CatalogFunctionController : BaseApiController
    {
        private readonly ICatalogFunctionService _catalogFunctionService;
        public CatalogFunctionController(ICatalogFunctionService catalogFunctionService)
        {
            _catalogFunctionService = catalogFunctionService;
        }

        [HttpGet]
        public IActionResult Get(string filter = "")
        {
            var model = _catalogFunctionService.GetAll(null);
            return Ok(model);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetCatalogFunction(string id)
        {
            var model = _catalogFunctionService.GetCatalogFunction(id);
            return Ok(model);
        }

        [HttpPost]
        public IActionResult Create(CatalogFunctionModel catModel)
        {
            if (ModelState.IsValid)
            {
                var newCat = _catalogFunctionService.Insert(base.UserId, catModel);
            }
            return Ok();
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult Update(string id, CatalogFunctionModel catModel)
        {
            if (ModelState.IsValid)
            {
                var updateCat = _catalogFunctionService.Update(id, base.UserId, catModel);
            }
            return Ok();
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(string id)
        {
            _catalogFunctionService.Delete(id, base.UserId);
            return Ok();
        }
    }
}