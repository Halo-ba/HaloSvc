using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.QueryObjects;
using Backend.Models;

namespace Backend.Interfaces
{
    public interface IArticleErrorRepository
    {
        Task<List<ArticleError>> GetAllAsync();
        Task<ArticleError?> GetByIdAsync(int id);
        Task<ArticleError> CreateAsync(ArticleError articleErrorModel);
        Task<ArticleError?> UpdateAsync(int id, ArticleError articleErrorModel);
        Task<ArticleError?> DeleteAsync(int id);
    }
}
//