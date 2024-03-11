using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Dtos.Article;
using Backend.Models;

namespace Backend.Mappers
{
    public static class ArticleMapper
    {
         public static ArticleDto ToArticleDto(this Article articleModel)
        {
            return new ArticleDto
            {
                Id = articleModel.Id,
                Title = articleModel.Title,
                Content = articleModel.Content,
                NumberOfShares = articleModel.NumberOfShares,
                PostDate = articleModel.PostDate,
                Comments = articleModel.Comments.Select(c => c.ToCommentDto()).ToList(),
                //After implementing Image and ArticleError, it will be added
                //Images = articleModel.Images.Select(c => c.ImageDto()).ToList(),
            };
        }

        public static Article ToArticleFromCreateDTO(this ArticleDto articleDto)
        {
            return new Article
            {
                Title = articleDto.Title,
                Content = articleDto.Content,
                NumberOfShares = articleDto.NumberOfShares,
                PostDate = articleDto.PostDate,
            };
        }

        }
}