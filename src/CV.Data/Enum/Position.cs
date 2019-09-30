using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CV.Data.Enum
{
    public enum Position
    {

        [Display(Name = "Hình trang chủ")]
        HomeSlide,

        [Display(Name = "Logo")]
        Logo
    }
}
