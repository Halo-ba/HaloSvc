using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Dtos.Comment;
using Backend.Mappers;
namespace Backend.Dtos.Advertisement;
{
    public class AdvertisementDto
    {
        public int Id { get; set; }
        public string? AdvertisementEmail { get; set; } = null;
        public DateTime? StartDate { get; set; }
        public int NumberOfDays { get; set; }
        public double? Price { get; set; }

        //Later to add MarketingTeamMember
    }
}