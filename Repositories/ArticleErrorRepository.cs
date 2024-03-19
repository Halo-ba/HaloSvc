using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Data;
using Backend.QueryObjects;
using Backend.Interfaces;
using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repositories
{
    public class ArticleErrorRepository : IArticleErrorRepository
    {
        private readonly ApplicationDbContext _context;
        public ArticleErrorRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ArticleError> CreateAsync(ArticleError articleErrorModel)
        {
            await _context.ArticleErrors.AddAsync(articleErrorModel);
            await _context.SaveChangesAsync();
            return articleErrorModel;
        }

        public async Task<ArticleError?> DeleteAsync(int id)
        {
            var articleErrorModel = await _context.ArticleErrors.FirstOrDefaultAsync(x => x.Id == id);

            if (articleErrorModel == null)
            {
                return null;
            }

            _context.ArticleErrors.Remove(articleErrorModel);
            await _context.SaveChangesAsync();
            return articleErrorModel;
        }

        //Get all article categories from database
        public async Task<List<ArticleError>> GetAllAsync()
        {
            return await _context.ArticleErrors.ToListAsync();
        }

        public async Task<ArticleError?> GetByIdAsync(int id)
        {
            return await _context.ArticleErrors.FirstOrDefaultAsync(ae => ae.Id == id);
        }

        public async Task<ArticleError?> UpdateAsync(int id, ArticleError articleErrorModel)
        {
            var existingArticleError = await _context.ArticleErrors.FindAsync(id);

            if (existingArticleError == null)
            {
                return null;
            }
            existingArticleError.Description = articleErrorModel.Description;

            await _context.SaveChangesAsync();

            return existingArticleError;
        }
    }
}