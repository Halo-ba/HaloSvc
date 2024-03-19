using System;
using System.ComponentModel.DataAnnotations;

public class Advertisement
{
    [Key] // Primary key
    public int Id { get; set; }

    [Required]
    [StringLength(50)]
    public string AdvertisementEmail { get; set; } = string.Empty;

    public DateTime? StartDate { get; set; }

    [Required]
    [Range(1, int.MaxValue)]
    public int NumberOfDays { get; set; }

    public double? Price { get; set; }

    // Foreign key
    public int MarketingTeamMemberId { get; set; }

    // Navigation property
    public MarketingTeamMember? MarketingTeamMember { get; set; }
}