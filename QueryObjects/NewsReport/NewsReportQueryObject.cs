using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//
namespace Backend.QueryObjects
{
    public class NewsReportQueryObject
    {
        public DateTime? DateOfReport { get; set; }
        public string? Reporter { get; set; }
        public string? SortBy { get; set; } = null;
        public bool IsDecsending { get; set; } = false;
    }
}