using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Dtos.Comment
{
    public class CommentDto
    {
        public int Id { get; set; }
        public string Content { get; set; } = string.Empty;
        public DateTime postDate { get; set; } = DateTime.Now;
        public int RegisteredUserId { get; set; }
        public int? ArticleId { get; set; }
    }
}