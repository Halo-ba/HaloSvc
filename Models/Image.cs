using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

public class Image
{
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(50)]
    public string Url { get; set; }

    // Foreign key for Article
    public int ArticleId { get; set; }
    public Article Article { get; set; } // Navigation property
}