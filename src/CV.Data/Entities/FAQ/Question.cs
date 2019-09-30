using CV.Utils.Helper;
using System;
using System.Collections.Generic;
using System.Text;

namespace CV.Data.Entities.FAQ
{
    public class Question : AuditTable
    {
        public Question()
        {
            Id = CoreHelper.GeneratorGuid;
        }

        public string Name { set; get; }

        public string Anwser { set; get; }

        public bool Active { set; get; } = true;

        public string GroupQuestionId { set; get; }

        public virtual GroupQuestion GroupQuestion { set; get; }
    }
}
