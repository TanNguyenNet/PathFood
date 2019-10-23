using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CV.Core.Endpoints;
using CV.Data.Model.Catalog;
using CV.Service.Interface.Catalog;
using CV.Service.Interface.Setting;
using Microsoft.AspNetCore.Mvc;

namespace CV.Web.Controllers
{
    public class CatalogController : BaseController
    {
        private readonly IProductService _productService;
        private readonly ICatalogFunctionService _catalogFunctionService;
        private readonly ICatalogSectorService _catalogSectorService;
        private readonly IWebImageService _webImageService;

        public CatalogController(IProductService productService,
            ICatalogFunctionService catalogFunctionService,
            ICatalogSectorService catalogSectorService,
            IWebImageService webImageService)
        {
            _productService = productService;
            _catalogFunctionService = catalogFunctionService;
            _catalogSectorService = catalogSectorService;
            _webImageService = webImageService;
        }

        [Route(CatalogEndpoints.IndexEndpoint)]
        [Route(CatalogEndpoints.FunctionEndpoint)]
        [Route(CatalogEndpoints.SectorEndpoint)]
        [HttpGet]
        public IActionResult Index(string function = "", string sector = "")
        {
            var model = new CatalogModel();
            model.CatalogFunctions = _catalogFunctionService.GetAll(CurrentLang);
            model.CatalogSectors = _catalogSectorService.GetAll(CurrentLang);

            if (!string.IsNullOrWhiteSpace(function))
            {
                model.Products = _productService.GetProductByFunction(function);
                model.Title = model.CatalogFunctions.Where(x => x.Slug == function).FirstOrDefault().Name;
            }

            else if (!string.IsNullOrWhiteSpace(sector))
            {
                model.Products = _productService.GetProductBySector(sector);
                model.Title = model.CatalogSectors.Where(x => x.Slug == sector).FirstOrDefault().Name;
            }

            else
            {
                model.Products = _productService.GetAll(CurrentLang);
                model.Title = "Tất cả";
            }

            ViewBag.UrlImage = _webImageService.GetAll(Data.Enum.Position.BreadcrumbProduct).FirstOrDefault()?.URLImage;

            return View(model);
        }
    }
}