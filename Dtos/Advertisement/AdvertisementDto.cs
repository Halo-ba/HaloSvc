using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Dtos.Comment;
using Backend.Mappers;
namespace Backend.Dtos.Article
{
    public class AdvertisementDto
    {
        public string? AdvertisementEmail { get; set; } = null;
        public DateTime? StartDate { get; set; }
        public int? NumberOfDays { get; set; }
        public double? Price { get; set; }

        //Later to add MarketingTeamMember
    }
}