using CV.Service.Interface.Setting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CV.Web.Controllers.ViewComponents
{
    public class LogoViewComponent: ViewComponent
    {
        private readonly IWebImageService _webImageService;
        public LogoViewComponent(IWebImageService webImageService)
        {
            _webImageService = webImageService;
        }
    }
}
