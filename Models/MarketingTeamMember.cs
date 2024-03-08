public class MarketingTeamMember : Person
{
    public DateTime HireDate { get; set; }
    public List<Advertisement> Advertisements { get; set; } = new List<Advertisement>(); // One-to-many relationship
}