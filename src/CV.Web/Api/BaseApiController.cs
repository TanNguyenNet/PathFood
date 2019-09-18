using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CV.Web.Api
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class BaseApiController : ControllerBase
    {


    }
}