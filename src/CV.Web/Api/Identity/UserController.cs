using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CV.Data.Authorization;
using CV.Data.Model.Identity;
using CV.Service.Interface.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CV.Web.Api.Identity
{

    public class UserController : BaseApiController
    {
        private readonly IUserIdentityService _userIdentityService;

        public UserController(IUserIdentityService userIdentityService)
        {
            _userIdentityService = userIdentityService;
        }

        [HttpGet]
        //[Authorize(Policy = nameof(ContantPolicy.User.ReadUserData))]
        public IActionResult Get(int page = 1, int pageSize = 20, string filter = "")
        {
            var model = _userIdentityService.GetAll(page, pageSize, filter);
            return Ok(model);
        }

        [HttpGet]
        [Route("{id}")]
        //[Authorize(Policy = nameof(ContantPolicy.User.ReadUserData))]
        public IActionResult GetUser(string id)
        {
            var model = _userIdentityService.GetUser(id);
            return Ok(model);
        }


        [HttpPost]
        public IActionResult Create(AppUserModel user)
        {
            if (ModelState.IsValid)
            {
                var newUser = _userIdentityService.Insert(user);
            }
            return Ok();
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update(string id, AppUserUpdateModel user)
        {
            if (ModelState.IsValid)
            {
                var updateUser = await _userIdentityService.Update(id,user);
            }
            return Ok();
        }

        [HttpPut]
        public IActionResult UpdatePassword(ChangePasswordModel model)
        {
            _userIdentityService.ChangePassword(base.UserId, model);
            return Ok();
        }
    }
}