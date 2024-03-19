using System.ComponentModel.DataAnnotations;

public class RegisteredUser : Person
{
    [Required]
    public DateTime RegistrationDate { get; set; }

    // Navigation property for Comment (one-to-many)
    public List<Comment> Comments { get; set; }
    public List<Comment> Comments { get; set; } = new List<Comment>();

    // Many-to-many relationship with Comment
    public List<Vote> Votes { get; set; }

    public List<Vote> Votes { get; set; } = new List<Vote>();
}