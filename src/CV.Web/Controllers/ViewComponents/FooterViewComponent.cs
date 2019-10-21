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

        public FooterViewComponent(IInfoService infoService)
        {
            _infoService = infoService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model = await Task.Run(() => Task.Run(() => _infoService.GetAll(Data.Enum.InfoType.InfoCompay)));
            return View("_Footer",model);
        }
    }
}
