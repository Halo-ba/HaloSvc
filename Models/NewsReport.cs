using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

public class NewsReport
{
    [Key]
    public int Id { get; set; }
    
    [Required]
    [StringLength(2000)]
    public string Text { get; set; } = string.Empty;
    public DateTime? DateOfReport { get; set; }
    
    [Required]
    [StringLength(50)]
    public string Reporter { get; set; } = string.Empty;
    [StringLength(50)]
    public string? ReporterTelephoneNumber { get; set; }
    [StringLength(50)]
    public string? Email { get; set; }

    // Foreign key
    public int JournalistId { get; set; }

    // Navigation property
    public Journalist? Journalist { get; set; }
}