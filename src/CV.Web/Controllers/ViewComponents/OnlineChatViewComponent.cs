using CV.Service.Interface.Setting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CV.Web.Controllers.ViewComponents
{
    public class OnlineChatViewComponent: ViewComponent
    {
        private readonly IInfoService _infoService;
        public OnlineChatViewComponent(IInfoService infoService)
        {
            _infoService = infoService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model = await Task.Run(() => Task.Run(() => _infoService.GetAll(Data.Enum.InfoType.Zalo)));
            return View("_OnlineChat", model);
        }
    }
}
