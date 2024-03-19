using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Backend.Models
{
    public class ArticleError
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(500)]
        public string Description { get; set; } = string.Empty;

        // Foreign key for Article
        public int ArticleId { get; set; }
        public Article? Article { get; set; } // Navigation property
    }
}