using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CV.Data.Entities.Identity
{
    [Table("AppUsers")]
    public class AppUser: IdentityUser<string>
    {
        public string FirstName { set; get; }

        public string LastName { set; get; }

        public DateTimeOffset? CreatedDate { set; get; }

        public DateTimeOffset? UpdatedDate { set; get; }

        public DateTimeOffset? DeletedDate { set; get; }

        [MaxLength(64)]
        public string CreatedBy { set; get; }

        [MaxLength(64)]
        public string UpdatedBy { set; get; }

        [MaxLength(64)]
        public string DeletedBy { set; get; }
    }
}
