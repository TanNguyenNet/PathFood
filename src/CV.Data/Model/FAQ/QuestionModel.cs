using System;
using System.Collections.Generic;
using System.Text;

namespace CV.Data.Model.FAQ
{
    public class QuestionModel: AuditTableModel
    {
        public string Name { set; get; }

        public string Anwser { set; get; }

        public bool Active { set; get; } = true;

        public string GroupQuestionId { set; get; }

        public string Slug { set; get; }

        public GroupQuestionModel GroupQuestion { set; get; }
    }
}
