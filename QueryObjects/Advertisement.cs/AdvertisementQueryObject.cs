using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.QueryObjects
{
    public class AdvertisementQueryObject
    {
        public DateTime? StartDate { get; set; }
        public int? NumberOfDays { get; set; }
        public double? Price { get; set; }
        public string? SortBy { get; set; } = null;
        public bool IsDecsending { get; set; } = false;
    }
}