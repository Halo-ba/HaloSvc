using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Dtos.CommentReport
{
    public class CommentReportDto
    {
        public int Id { get; set; }
        public string ReportDescription { get; set; } = string.Empty;
        public int? CommentId { get; set; }
    }
}
//