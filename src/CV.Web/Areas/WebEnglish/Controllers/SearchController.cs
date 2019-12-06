using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CV.Core.Endpoints;
using CV.Service.Interface.Setting;
using Microsoft.AspNetCore.Mvc;

namespace CV.Web.Areas.WebEnglish.Controllers
{
    public class SearchController : BaseController
    {
        private readonly ISearchService _searchService;

        public SearchController(ISearchService searchService)
        {
            _searchService = searchService;
        }

        [HttpGet]
        [Route(SearchEndpoints.EnglishIndexEndpoint)]
        public IActionResult Index(string filter)
        {
            var model = _searchService.GetAll(filter, base.CurrentLang);
            return View(model);
        }
    }
}