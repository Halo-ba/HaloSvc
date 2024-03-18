using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//
namespace Backend.QueryObjects
{
    public class ArticleQueryObject
    {
        public DateTime? PostDate { get; set; }
        public int? NumberOfShares { get; set; }
        public string? SortBy { get; set; } = null;
        public bool IsDecsending { get; set; } = false;
        //Pagination
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 20;
    }
}