using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

public class ArticleCategory
{
    [Key]   
    public int Id { get; set; }
    
    [Required]
    [StringLength(50)]
    public string Name { get; set; }

    // Navigation property for Article (many-to-one)
    public List<Article> Articles { get; set; }
}