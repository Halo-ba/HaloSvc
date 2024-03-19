using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Backend.Models 
{
    public class Journalist : Person
    {

        [Required]
        public DateTime HireDate { get; set; }
        public List<NewsReport> NewsReport { get; set; } = new List<NewsReport>(); // One-to-many relationship
        public List<Article> Articles { get; set; } = new List<Article>();
    }
}