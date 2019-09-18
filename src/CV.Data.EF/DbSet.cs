using CV.Data.Entities.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CV.Data.EF
{
    public sealed partial class CVContext
    {
        public DbSet<AppUser> AppUsers { set; get; }

        public DbSet<AppRole> AppRoles { get; set; }
    }
}
