using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

public class Vote
{
    public int Id { get; set; }
    public VoteType VoteType { get; set; }

    // Foreign key for Comment
    public int CommentId { get; set; }
    public Comment Comment { get; set; } // Navigation property

    // Foreign key for RegisteredUser
    public int RegisteredUserId { get; set; }
    public RegisteredUser RegisteredUser { get; set; } // Navigation property
}