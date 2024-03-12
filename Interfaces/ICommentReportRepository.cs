using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.QueryObjects;
using Backend.Models;

namespace Backend.Interfaces
{
    public interface ICommentReportRepository
    {
        Task<List<CommentReport>> GetAllAsync();
        Task<CommentReport?> GetByIdAsync(int id);
        Task<CommentReport?> GetByCommentIdAsync(int id);
        Task<CommentReport> CreateAsync(int commentId, CommentReport commentReportModel);
        Task<CommentReport?> UpdateAsync(int id, CommentReport commentReportModel);
        Task<CommentReport?> DeleteAsync(int id);
    }
}