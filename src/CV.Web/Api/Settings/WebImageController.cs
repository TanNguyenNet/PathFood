using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CV.Service.Interface.Setting;
using Microsoft.AspNetCore.Mvc;

namespace CV.Web.Api.Settings
{
    public class WebImageController : BaseApiController
    {
        private readonly IWebImageService _webImageService;

        public WebImageController(IWebImageService webImageService)
        {
            _webImageService = webImageService;
        }
    }
}