using CV.Utils.Helper;
using System;
using System.Collections.Generic;
using System.Text;

namespace CV.Data.Entities.FAQ
{
    public class GroupQuestion : AuditTable
    {
        public GroupQuestion()
        {
            Id = CoreHelper.GeneratorGuid;
        }

        public string Name { set; get; }

        public bool Active { set; get; } = true;

        public virtual ICollection<Question> Question { set; get; }
    }
}
