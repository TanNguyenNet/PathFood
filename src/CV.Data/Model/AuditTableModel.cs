using System;
using System.Collections.Generic;
using System.Text;

namespace CV.Data.Model
{
    public class AuditTableModel : BaseEntityModel
    {
        public DateTimeOffset CreatedTime { get; set; }

        public DateTimeOffset LastUpdatedTime { get; set; }

        public DateTimeOffset? DeletedTime { get; set; }

        public string CreatedBy { get; set; }

        public string LastUpdatedBy { get; set; }

        public string DeletedBy { get; set; }
    }
}
