using CV.Data.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace CV.Data.Model
{
    public class BaseEntityModel
    {
        public string Id { set; get; }

        public Languages Lang { set; get; }
    }
}
