using CV.Service.Interface.Setting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CV.Web.Areas.WebEnglish.Controllers.ViewComponents
{
    public class EnOnlineChatViewComponent : ViewComponent
    {
        private readonly IInfoService _infoService;
        public EnOnlineChatViewComponent(IInfoService infoService)
        {
            _infoService = infoService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model = await Task.Run(() => _infoService.GetAll(Data.Enum.InfoType.Zalo));
            return View("_OnlineChat", model);
        }
    }
}
