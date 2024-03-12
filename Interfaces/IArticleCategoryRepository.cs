using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.QueryObjects;
using Backend.Models;

namespace Backend.Interfaces
{
    public interface IArticleCategoryRepository
    {
        Task<List<ArticleCategory>> GetAllAsync();
        Task<ArticleCategory?> GetByIdAsync(int id);
        Task<ArticleCategory> CreateAsync(ArticleCategory articleCategoryModel);
        Task<ArticleCategory?> UpdateAsync(int id, ArticleCategory articleCategoryModel);
        Task<ArticleCategory?> DeleteAsync(int id);
    }
}