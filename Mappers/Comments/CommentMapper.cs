using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Dtos.Comment;
using Backend.Models;

namespace Backend.Mappers
{
    public static class CommentMapper
    {
        public static CommentDto ToCommentDto(this Comment commentModel)
        {
            return new CommentDto
            {
                Id = commentModel.Id,
                Content = commentModel.Content,
                postDate = commentModel.PostDate,
                RegisteredUserId = commentModel.RegisteredUserId,
                ArticleId = commentModel.ArticleId
            };
        }

        public static Comment ToCommentFromCreate(this CommentDto commentDto, int articleId, int RegisteredUserId)
        {
            return new Comment
            {
                Content = commentDto.Content,
                ArticleId = articleId,
                RegisteredUserId = RegisteredUserId
            };
        }

        public static Comment ToCommentFromUpdate(this UpdateCommentRequestDto commentDto, int articleId)
        {
            return new Comment
            {
                Content = commentDto.Content,
                ArticleId = articleId
            };
        }

    }
}