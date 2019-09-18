using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CV.Data.Model.Identity
{
    public class AppUserUpdateModel
    {
        public string UserName { set; get; }

        public string FirstName { set; get; }

        public string LastName { set; get; }

        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { set; get; }

        public IEnumerable<ClaimRequirementModel> Claims { set; get; }
    }
}
