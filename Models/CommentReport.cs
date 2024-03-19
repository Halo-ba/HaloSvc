using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Backend.Models
{
    public class CommentReport
    {
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string ReportDescription { get; set; } = string.Empty;

        // Foreign key for Comment
        public int CommentId { get; set; }
        public Comment? Comment { get; set; } // Navigation property
    }
}