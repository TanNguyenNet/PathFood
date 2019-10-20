using CV.Data.Model.Page;
using CV.Service.Interface.Blog;
using CV.Service.Interface.Catalog;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CV.Web.Controllers.ViewComponents
{
    public class HeaderViewComponent : ViewComponent
    {
        private readonly ICatalogFunctionService _catalogFunctionService;
        private readonly ICatalogSectorService _catalogSectorService;
        private readonly ICategoryBlogService _categoryBlogService;
        private readonly IPageContentService _pageContentService;

        public HeaderViewComponent(ICatalogFunctionService catalogFunctionService, 
            ICatalogSectorService catalogSectorService,
            ICategoryBlogService categoryBlogService,
            IPageContentService pageContentService)
        {
            _catalogFunctionService = catalogFunctionService;
            _catalogSectorService = catalogSectorService;
            _categoryBlogService = categoryBlogService;
            _pageContentService = pageContentService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model = new HeaderModel();
            model.CatalogFunctions = await Task.Run(() => Task.Run(() => _catalogFunctionService.GetAll(Data.Enum.Languages.Vi, true)));
            model.CatalogSectors = _catalogSectorService.GetAll(Data.Enum.Languages.Vi, true);
            model.CategoryBlogs = _categoryBlogService.GetAll(Data.Enum.Languages.Vi);
            model.PageContents = _pageContentService.GetAll(false);
            return View("_Header", model);
        }
    }
}
