using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

public class Comment
{
    public int Id { get; set; }

    [Required]
    [StringLength(1000)]
    public string Content { get; set; }

    public DateTime? PostDate { get; set; }

    // Foreign key for ArticleCategory
    public int ArticleId { get; set; }
    public Article Article { get; set; } // Navigation property

    // Foreign key for RegisteredUser
    public int RegisteredUserId { get; set; }
    public RegisteredUser RegisteredUser { get; set; } // Navigation property

    // Navigation property for CommentReport (one-to-many)
    public List<CommentReport> CommentReports { get; set; }

    // Many-to-many relationship with RegisteredUser
    public List<Vote> Votes { get; set; }
}