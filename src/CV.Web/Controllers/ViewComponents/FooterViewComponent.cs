using CV.Data.Model.Page;
using CV.Service.Interface.Blog;
using CV.Service.Interface.Setting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CV.Web.Controllers.ViewComponents
{
    public class FooterViewComponent : ViewComponent
    {
        private readonly IInfoService _infoService;
        private readonly IPageContentService _pageContentService;

        public FooterViewComponent(IInfoService infoService, IPageContentService pageContentService)
        {
            _infoService = infoService;
            _pageContentService = pageContentService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var footerModel = new FooterModel();
            footerModel.Infos = await Task.Run(()  => _infoService.GetAll(Data.Enum.InfoType.InfoCompay));
            footerModel.PageContents = _pageContentService.GetAll(true, Data.Enum.Languages.Vi);
            return View("_Footer", footerModel);
        }
    }
}
