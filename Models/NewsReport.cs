using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

public class NewsReport
{
    public int Id { get; set; }
    public string Text { get; set; }
    public DateTime? DateOfReport { get; set; }
    public string Reporter { get; set; }
    public string ReporterTelephoneNumber { get; set; }
    public string Email { get; set; }

    // Foreign key
    public int JournalistId { get; set; }

    // Navigation property
    public Journalist Journalist { get; set; }
}