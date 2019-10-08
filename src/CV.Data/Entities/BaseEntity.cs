using CV.Data.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace CV.Data.Entities
{
    public class BaseEntity
    {
        public string Id { set; get; }

        public Languages Lang { set; get; } = Languages.Vi;

        public bool IsTransient()
        {
            return Id.Equals(default(string));
        }
    }
}
