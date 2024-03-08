using System.ComponentModel.DataAnnotations;

public class Person
{
    [Key]
    public int Id { get; set; }

    [StringLength(50)]
    public string? Name { get; set; }

    [StringLength(50)]
    public string? Surname { get; set; }

    [Required]
    [StringLength(50)]
    public string Username { get; set; } = string.Empty;

    [Required]
    [StringLength(64)]
    public string PasswordHash { get; set; } = string.Empty;
}
