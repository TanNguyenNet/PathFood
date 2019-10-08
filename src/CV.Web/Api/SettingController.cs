using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CV.Core;
using CV.Service.Interface.Setting;
using CV.Utils.Utils.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CV.Web.Api
{
    public class SettingController : BaseApiController
    {
        private readonly ILanguageService _languageService;
        private readonly IHostingEnvironment _hostingEnvironment;
        public SettingController(ILanguageService languageService, IHostingEnvironment hostingEnvironment)
        {
            _languageService = languageService;
            _hostingEnvironment = hostingEnvironment;
        }

        public IActionResult GetLanguages()
        {
            var model = _languageService.Get();
            return Ok(model);
        }

        [HttpPost]
        public async Task<IActionResult> UploadFileAsync(IFormFile file)
        {
            try
            {
                var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "UploadFiles", file.FileName);
                var rootPath = Path.Combine(_hostingEnvironment.WebRootPath, "UploadFiles");
                if (file.Length > 0)
                {
                    DirectoryHelper.CreateIfNotExist(rootPath);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }
                }
                var url = $"/UploadFiles/{file.FileName}";
                return Ok(url);
            }
            catch (Exception ex)
            {
                throw;
            }
            
        }
    }
}