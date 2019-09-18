using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CV.Service.Interface.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CV.Web.Api.Identity
{
    public class PolicyController : BaseApiController
    {
        private readonly IPolicyService _policyService;
        public PolicyController(IPolicyService policyService)
        {
            _policyService = policyService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var model = _policyService.GetAll();
            return Ok(model);
        }
    }
}