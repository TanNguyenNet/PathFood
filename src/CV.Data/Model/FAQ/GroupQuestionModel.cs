using System;
using System.Collections.Generic;
using System.Text;

namespace CV.Data.Model.FAQ
{
    public class GroupQuestionModel:AuditTableModel
    {
        public string Name { set; get; }

        public bool Active { set; get; } = true;

        public string Slug { set; get; }

        public ICollection<QuestionModel> Question { set; get; }
    }
}
