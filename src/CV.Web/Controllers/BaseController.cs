using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CV.Data.Enum;
using Microsoft.AspNetCore.Mvc;

namespace CV.Web.Controllers
{
    public class BaseController : Controller
    {
        protected Languages CurrentLang
        {
            get
            {
                return Languages.Vi;
            }
        }
    }
}