using CV.Data.Entities.Blog;
using CV.Data.Entities.Catalog;
using CV.Data.Entities.FAQ;
using CV.Data.Entities.Identity;
using CV.Data.Entities.Setting;
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

        public DbSet<Product> Products { set; get; }

        public DbSet<CatalogFunction> CatalogFunctions { set; get; }

        public DbSet<CatalogSector> CatalogSectors { set; get; }

        public DbSet<Post> Posts { set; get; }

        public DbSet<CategoryBlog> CategoryBlogs { set; get; }

        public DbSet<GroupQuestion> GroupQuestions { set; get; }

        public DbSet<Question> Questions { set; get; }

        public DbSet<WebImage> WebImages { set; get; }
    }
}
