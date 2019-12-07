using CV.Data.Model.Page;
using CV.Service.Interface.Blog;
using CV.Service.Interface.Catalog;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CV.Web.Areas.WebEnglish.Controllers.ViewComponents
{
    public class EnHeaderViewComponent : ViewComponent
    {
        private readonly ICatalogFunctionService _catalogFunctionService;
        private readonly ICatalogSectorService _catalogSectorService;
        private readonly ICategoryBlogService _categoryBlogService;
        private readonly IPageContentService _pageContentService;

        public EnHeaderViewComponent(ICatalogFunctionService catalogFunctionService,
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
            model.CatalogFunctions = await Task.Run(() => _catalogFunctionService.GetAll(Data.Enum.Languages.En, true));
            model.CatalogSectors = _catalogSectorService.GetAll(Data.Enum.Languages.En, true);
            model.CategoryBlogs = _categoryBlogService.GetAll(Data.Enum.Languages.En);
            model.PageContents = _pageContentService.GetAll(false, Data.Enum.Languages.En);
            return View("_Header", model);
        }
    }
}
