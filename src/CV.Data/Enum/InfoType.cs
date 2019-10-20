using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CV.Data.Enum
{
    public enum InfoType
    {
        [Display(Name = "Thông tin CTY")]
        InfoCompay,

        [Display(Name = "Zalo")]
        Zalo,

        [Display(Name = "Cấu hình email")]
        Email
    }
}
