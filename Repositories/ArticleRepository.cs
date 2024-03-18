using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Data;
using Backend.Dtos.Article;
using Backend.QueryObjects;
using Backend.Interfaces;
using Backend.Models;
using Microsoft.EntityFrameworkCore;
using Backend.Mappers;
//
namespace Backend.Repositories
{
    public class ArticleRepository : IArticleRepository
    {
        private readonly ApplicationDbContext _context;
        public ArticleRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Article?> CreateAsync(Article articleModel)
        {
            await _context.Articles.AddAsync(articleModel);
            await _context.SaveChangesAsync();
            return articleModel;
        }

        public async Task<Article?> DeleteAsync(int id)
        {
            var articleModel = await _context.Articles.FirstOrDefaultAsync(x => x.Id == id);

            if (articleModel == null)
            {
                return null;
            }

            _context.Articles.Remove(articleModel);
            await _context.SaveChangesAsync();
            return articleModel;
        }

        public async Task<List<Article>> GetAllAsync(ArticleQueryObject query)
        {
            var articles = _context.Articles.Include(c => c.Comments).ThenInclude(a => a.RegisteredUser).AsQueryable();

            if (!string.IsNullOrWhiteSpace(query.SortBy))
            {
                if (query.SortBy.Equals("PostDate", StringComparison.OrdinalIgnoreCase))
                {
                    articles = query.IsDecsending ? articles.OrderByDescending(s => s.PostDate) : articles.OrderBy(s => s.PostDate);
                }
                else if(query.SortBy.Equals("NumberOfShares", StringComparison.OrdinalIgnoreCase)) {
                    articles = query.IsDecsending ? articles.OrderByDescending(s => s.NumberOfShares) : articles.OrderBy(s => s.NumberOfShares);
                }
            }

            var skipNumber = (query.PageNumber - 1) * query.PageSize;


            return await articles.Skip(skipNumber).Take(query.PageSize).ToListAsync();
        }

        public async Task<Article?> GetByIdAsync(int id)
        {
            return await _context.Articles.Include(c => c.Comments).FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<Article?> GetByTitleAsync(string title)
        {
            return await _context.Articles.FirstOrDefaultAsync(s => s.Title == title);
        }

        public Task<bool> ArticleExists(int id)
        {
            return _context.Articles.AnyAsync(s => s.Id == id);
        }

        public async Task<Article?> UpdateAsync(int id, ArticleDto articleDto)
        {
            var existingArticle = await _context.Articles.FirstOrDefaultAsync(x => x.Id == id);

            if (existingArticle == null)
            {
                return null;
            }
            existingArticle = articleDto.ToArticleFromCreateDTO();

            await _context.SaveChangesAsync();

            return existingArticle;
        }
    }
}