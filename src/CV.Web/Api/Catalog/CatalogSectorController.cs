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
    public class CatalogSectorController : BaseApiController
    {

        private readonly ICatalogSectorService _catalogSectorService;
        public CatalogSectorController(ICatalogSectorService catalogSectorService)
        {
            _catalogSectorService = catalogSectorService;
        }

        [HttpGet]
        public IActionResult Get(string filter = "")
        {
            var model = _catalogSectorService.GetAll(null);
            return Ok(model);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetCatalogSector(string id)
        {
            var model = _catalogSectorService.GetCatalogSector(id);
            return Ok(model);
        }

        [HttpPost]
        public IActionResult Create(CatalogSectorModel catModel)
        {
            if (ModelState.IsValid)
            {
                var newCat = _catalogSectorService.Insert(base.UserId, catModel);
            }
            return Ok();
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult Update(string id, CatalogSectorModel catModel)
        {
            if (ModelState.IsValid)
            {
                var updateCat = _catalogSectorService.Update(id, base.UserId, catModel);
            }
            return Ok();
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(string id)
        {
            _catalogSectorService.Delete(id, base.UserId);
            return Ok();
        }
    }
}