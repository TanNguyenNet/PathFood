using CV.Data.Model.Identity;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace CV.Service.Interface.Identity
{
    public interface IPolicyService
    {

        IEnumerable<ClaimRequirementModel> GetAll();
    }
}
