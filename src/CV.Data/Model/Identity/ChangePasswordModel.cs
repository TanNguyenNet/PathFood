using System;
using System.Collections.Generic;
using System.Text;

namespace CV.Data.Model.Identity
{
    public class ChangePasswordModel
    {
        public string OldPassword { set; get; }

        public string NewPassword { set; get; }
    }
}
