using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Backend.Models 
{
    public class Article
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string Title { get; set; } = string.Empty;

        [Required]
        [StringLength(20000)]

        public int? NumberOfShares { get; set; }

        public DateTime? PostDate { get; set; }

        // Foreign key for ArticleCategory
        public int ArticleCategoryId { get; set; }

        public ArticleCategory? ArticleCategory { get; set; } // Navigation property

        // Foreign key for Journalist
        public int JournalistId { get; set; }
        public Journalist? Journalist { get; set; } // Navigation property

        // Navigation property for Image (one-to-many)
        public List<Image> Images { get; set; } = new List<Image>();

        // Navigation property for ArticleError (one-to-many)
        public List<ArticleError> ArticleErrors { get; set; } = new List<ArticleError>();
        
        // Navigation property for Comments (one-to-many)
        public List<Comment> Comments { get; set; } = new List<Comment>();
    }
}
