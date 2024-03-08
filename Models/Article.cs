using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

public class Article
{
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(200)]
    public string Title { get; set; }

    [Required]
    [StringLength(20000)]
    public string Content { get; set; }

    [Required]
    public int NumberOfShares { get; set; }

    public DateTime? PostDate { get; set; }

    // Foreign key for ArticleCategory
    public int ArticleCategoryId { get; set; }
    public ArticleCategory ArticleCategory { get; set; } // Navigation property

    // Foreign key for Journalist
    public int JournalistId { get; set; }
    public Journalist Journalist { get; set; } // Navigation property

    // Navigation property for Image (one-to-many)
    public List<Image> Images { get; set; }

    // Navigation property for ArticleError (one-to-many)
    public List<ArticleError> ArticleErrors { get; set; }
}