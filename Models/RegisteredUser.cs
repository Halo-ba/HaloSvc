public class RegisteredUser : Person
{
    public DateTime RegistrationDate { get; set; }

    // Navigation property for Comment (one-to-many)
    public List<Comment> Comments { get; set; }

    // Many-to-many relationship with Comment
    public List<Vote> Votes { get; set; }

}