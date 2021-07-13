using System;

namespace API.PowerBI.Models
{
    public class ReportInput
    {
        public Guid WorkspaceID { get; set; }
        public Guid ReportID { get; set; }
    }
}
