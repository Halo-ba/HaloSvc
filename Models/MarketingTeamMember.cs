using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
//
namespace Backend.Models
{
    public class MarketingTeamMember : Person
    {
        [Required]
        public DateTime HireDate { get; set; }
        public List<Advertisement> Advertisements { get; set; } = new List<Advertisement>(); // One-to-many relationship
    }
}