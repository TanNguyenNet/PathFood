﻿// <auto-generated />
using System;
using CV.Data.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CV.Data.EF.Migrations
{
    [DbContext(typeof(CVContext))]
    [Migration("20191020143350_addTablePageContentAndInfo")]
    partial class addTablePageContentAndInfo
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CV.Data.Entities.Blog.CategoryBlog", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Active");

                    b.Property<string>("CreatedBy");

                    b.Property<DateTimeOffset>("CreatedTime");

                    b.Property<string>("DeletedBy");

                    b.Property<DateTimeOffset?>("DeletedTime");

                    b.Property<string>("Description");

                    b.Property<int>("Lang");

                    b.Property<string>("LastUpdatedBy");

                    b.Property<DateTimeOffset>("LastUpdatedTime");

                    b.Property<string>("Name");

                    b.Property<bool>("SetHomePage");

                    b.Property<string>("Slug");

                    b.Property<string>("UrlImage");

                    b.HasKey("Id");

                    b.ToTable("CategoryBlogs");
                });

            modelBuilder.Entity("CV.Data.Entities.Blog.PageContent", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Content");

                    b.Property<string>("CreatedBy");

                    b.Property<DateTimeOffset>("CreatedTime");

                    b.Property<string>("DeletedBy");

                    b.Property<DateTimeOffset?>("DeletedTime");

                    b.Property<string>("Description");

                    b.Property<bool>("Home");

                    b.Property<int>("Lang");

                    b.Property<string>("LastUpdatedBy");

                    b.Property<DateTimeOffset>("LastUpdatedTime");

                    b.Property<string>("Name");

                    b.Property<string>("Slug");

                    b.Property<string>("URLImage");

                    b.HasKey("Id");

                    b.ToTable("PageContents");
                });

            modelBuilder.Entity("CV.Data.Entities.Blog.Post", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Active");

                    b.Property<string>("CategoryBlogId");

                    b.Property<string>("Content");

                    b.Property<string>("CreatedBy");

                    b.Property<DateTimeOffset>("CreatedTime");

                    b.Property<string>("DeletedBy");

                    b.Property<DateTimeOffset?>("DeletedTime");

                    b.Property<string>("Description");

                    b.Property<int>("Lang");

                    b.Property<string>("LastUpdatedBy");

                    b.Property<DateTimeOffset>("LastUpdatedTime");

                    b.Property<string>("Name");

                    b.Property<DateTimeOffset?>("PushlishDate");

                    b.Property<bool>("SetHomePage");

                    b.Property<string>("Slug");

                    b.Property<string>("UrlImage");

                    b.HasKey("Id");

                    b.HasIndex("CategoryBlogId");

                    b.ToTable("Posts");
                });

            modelBuilder.Entity("CV.Data.Entities.Catalog.CatalogFunction", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Active");

                    b.Property<string>("Color");

                    b.Property<string>("CreatedBy");

                    b.Property<DateTimeOffset>("CreatedTime");

                    b.Property<string>("DeletedBy");

                    b.Property<DateTimeOffset?>("DeletedTime");

                    b.Property<string>("Description");

                    b.Property<int>("Lang");

                    b.Property<string>("LastUpdatedBy");

                    b.Property<DateTimeOffset>("LastUpdatedTime");

                    b.Property<string>("Name");

                    b.Property<string>("Slug");

                    b.Property<string>("URLImage");

                    b.HasKey("Id");

                    b.ToTable("CatalogFunctions");
                });

            modelBuilder.Entity("CV.Data.Entities.Catalog.CatalogSector", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Active");

                    b.Property<string>("Color");

                    b.Property<string>("CreatedBy");

                    b.Property<DateTimeOffset>("CreatedTime");

                    b.Property<string>("DeletedBy");

                    b.Property<DateTimeOffset?>("DeletedTime");

                    b.Property<string>("Description");

                    b.Property<int>("Lang");

                    b.Property<string>("LastUpdatedBy");

                    b.Property<DateTimeOffset>("LastUpdatedTime");

                    b.Property<string>("Name");

                    b.Property<string>("Slug");

                    b.Property<string>("URLImage");

                    b.HasKey("Id");

                    b.ToTable("CatalogSectors");
                });

            modelBuilder.Entity("CV.Data.Entities.Catalog.Product", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Active");

                    b.Property<string>("CatalogFunctionId");

                    b.Property<string>("CatalogSectorId");

                    b.Property<string>("Color");

                    b.Property<string>("CreatedBy");

                    b.Property<DateTimeOffset>("CreatedTime");

                    b.Property<string>("DeletedBy");

                    b.Property<DateTimeOffset?>("DeletedTime");

                    b.Property<string>("Description");

                    b.Property<int>("Lang");

                    b.Property<string>("LastUpdatedBy");

                    b.Property<DateTimeOffset>("LastUpdatedTime");

                    b.Property<string>("Name");

                    b.Property<bool>("New");

                    b.Property<string>("Slug");

                    b.HasKey("Id");

                    b.HasIndex("CatalogFunctionId");

                    b.HasIndex("CatalogSectorId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("CV.Data.Entities.FAQ.GroupQuestion", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Active");

                    b.Property<string>("CreatedBy");

                    b.Property<DateTimeOffset>("CreatedTime");

                    b.Property<string>("DeletedBy");

                    b.Property<DateTimeOffset?>("DeletedTime");

                    b.Property<int>("Lang");

                    b.Property<string>("LastUpdatedBy");

                    b.Property<DateTimeOffset>("LastUpdatedTime");

                    b.Property<string>("Name");

                    b.Property<string>("Slug");

                    b.HasKey("Id");

                    b.ToTable("GroupQuestions");
                });

            modelBuilder.Entity("CV.Data.Entities.FAQ.Question", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Active");

                    b.Property<string>("Anwser");

                    b.Property<string>("CreatedBy");

                    b.Property<DateTimeOffset>("CreatedTime");

                    b.Property<string>("DeletedBy");

                    b.Property<DateTimeOffset?>("DeletedTime");

                    b.Property<string>("GroupQuestionId");

                    b.Property<int>("Lang");

                    b.Property<string>("LastUpdatedBy");

                    b.Property<DateTimeOffset>("LastUpdatedTime");

                    b.Property<string>("Name");

                    b.Property<string>("Slug");

                    b.HasKey("Id");

                    b.HasIndex("GroupQuestionId");

                    b.ToTable("Questions");
                });

            modelBuilder.Entity("CV.Data.Entities.Identity.AppRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp");

                    b.Property<string>("Description")
                        .HasMaxLength(250);

                    b.Property<string>("Name");

                    b.Property<string>("NormalizedName");

                    b.HasKey("Id");

                    b.ToTable("AppRoles");
                });

            modelBuilder.Entity("CV.Data.Entities.Identity.AppUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp");

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(64);

                    b.Property<DateTimeOffset?>("CreatedDate");

                    b.Property<string>("DeletedBy")
                        .HasMaxLength(64);

                    b.Property<DateTimeOffset?>("DeletedDate");

                    b.Property<string>("Email");

                    b.Property<bool>("EmailConfirmed");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail");

                    b.Property<string>("NormalizedUserName");

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UpdatedBy")
                        .HasMaxLength(64);

                    b.Property<DateTimeOffset?>("UpdatedDate");

                    b.Property<string>("UserName");

                    b.HasKey("Id");

                    b.ToTable("AppUsers");
                });

            modelBuilder.Entity("CV.Data.Entities.Setting.Info", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address");

                    b.Property<string>("CreatedBy");

                    b.Property<DateTimeOffset>("CreatedTime");

                    b.Property<string>("DeletedBy");

                    b.Property<DateTimeOffset?>("DeletedTime");

                    b.Property<string>("Email");

                    b.Property<string>("Fax");

                    b.Property<string>("Hotline");

                    b.Property<int>("InfoType");

                    b.Property<int>("Lang");

                    b.Property<string>("LastUpdatedBy");

                    b.Property<DateTimeOffset>("LastUpdatedTime");

                    b.Property<string>("Name");

                    b.Property<string>("Password");

                    b.Property<string>("Phone");

                    b.Property<string>("PortEmail");

                    b.Property<string>("SmtpEmail");

                    b.Property<string>("Zalo");

                    b.HasKey("Id");

                    b.ToTable("Infos");
                });

            modelBuilder.Entity("CV.Data.Entities.Setting.WebImage", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CreatedBy");

                    b.Property<DateTimeOffset>("CreatedTime");

                    b.Property<string>("DeletedBy");

                    b.Property<DateTimeOffset?>("DeletedTime");

                    b.Property<int>("Lang");

                    b.Property<string>("LastUpdatedBy");

                    b.Property<DateTimeOffset>("LastUpdatedTime");

                    b.Property<string>("Name");

                    b.Property<int>("Position");

                    b.Property<string>("URL");

                    b.Property<string>("URLImage");

                    b.HasKey("Id");

                    b.ToTable("WebImages");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId");

                    b.HasKey("Id");

                    b.ToTable("AppRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.ToTable("AppUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("UserId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("ProviderKey");

                    b.HasKey("UserId");

                    b.ToTable("AppUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("RoleId");

                    b.Property<string>("UserId");

                    b.HasKey("RoleId", "UserId");

                    b.ToTable("AppUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId");

                    b.ToTable("AppUserTokens");
                });

            modelBuilder.Entity("CV.Data.Entities.Blog.Post", b =>
                {
                    b.HasOne("CV.Data.Entities.Blog.CategoryBlog", "CategoryBlog")
                        .WithMany("Post")
                        .HasForeignKey("CategoryBlogId");
                });

            modelBuilder.Entity("CV.Data.Entities.Catalog.Product", b =>
                {
                    b.HasOne("CV.Data.Entities.Catalog.CatalogFunction", "CatalogFunction")
                        .WithMany("Product")
                        .HasForeignKey("CatalogFunctionId");

                    b.HasOne("CV.Data.Entities.Catalog.CatalogSector", "CatalogSector")
                        .WithMany("Product")
                        .HasForeignKey("CatalogSectorId");
                });

            modelBuilder.Entity("CV.Data.Entities.FAQ.Question", b =>
                {
                    b.HasOne("CV.Data.Entities.FAQ.GroupQuestion", "GroupQuestion")
                        .WithMany("Question")
                        .HasForeignKey("GroupQuestionId");
                });
#pragma warning restore 612, 618
        }
    }
}
