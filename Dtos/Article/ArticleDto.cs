using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Dtos.Comment;
using Backend.Mappers;
namespace Backend.Dtos.Article
{
    public class ArticleDto
    {
        public int Id { get; set; }
        
        public string Title { get; set; } = string.Empty;
        
        public string Content { get; set; } = string.Empty;
        
        public int NumberOfShares { get; set; }

        public DateTime? PostDate { get; set; }

        public int JournalistId { get; set; }

        //Will add attributes for images and article error...
        public List<CommentDto> Comments { get; set; } = new List<CommentDto>();
    }
}