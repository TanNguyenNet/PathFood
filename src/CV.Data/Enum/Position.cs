using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CV.Data.Enum
{
    public enum Position
    {

        [Display(Name = "Hình slide trang chủ")]
        HomeSlide,

        [Display(Name = "Logo")]
        Logo,

        [Display(Name = "Hình Breadcrumb sản phẩm")]
        BreadcrumbProduct,

        [Display(Name = "Hình Breadcrumb tin tức")]
        BreadcrumbNews,

        [Display(Name = "Hình Breadcrumb Ứng dụng")]
        BreadcrumbIntegrate,

        [Display(Name = "Hình Breadcrumb FAQ")]
        BreadcrumbFAQ,

        [Display(Name = "Hình Breadcrumb liên hệ")]
        BreadcrumbContact
    }
}
