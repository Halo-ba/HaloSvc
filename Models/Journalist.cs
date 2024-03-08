public class Journalist : Person
{
    public DateTime HireDate { get; set; }
    public List<NewsReport> NewsReport { get; set; } = new List<NewsReport>(); // One-to-many relationship
    public List<Article> Articles { get; set; }
}