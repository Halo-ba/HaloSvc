using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Dtos.Article;
using Backend.Interfaces;
using Backend.Models;
using Backend.QueryObjects;

namespace Backend.Interfaces
{
    public interface IArticleRepository
    {
        Task<List<Article>> GetAllAsync(ArticleQueryObject query);
        Task<Article?> GetByIdAsync(int id);
        Task<Article?> GetByTitleAsync(string title);
        Task<Article> CreateAsync(Article articleModel);
        Task<Article?> UpdateAsync(int id, ArticleDto articleDto);
        Task<Article?> DeleteAsync(int id);
        Task<bool> ArticleExists(int id);
    }
}