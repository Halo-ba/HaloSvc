using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Data;
using Backend.QueryObjects;
using Backend.Interfaces;
using Backend.Models;
using Microsoft.EntityFrameworkCore;
//
namespace Backend.Repositories
{
    public class ArticleCategoryRepository : IArticleCategoryRepository
    {
        private readonly ApplicationDbContext _context;
        public ArticleCategoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ArticleCategory> CreateAsync(ArticleCategory articleCategoryModel)
        {
            await _context.ArticleCategories.AddAsync(articleCategoryModel);
            await _context.SaveChangesAsync();
            return articleCategoryModel;
        }

        public async Task<ArticleCategory?> DeleteAsync(int id)
        {
            var articleCategoryModel = await _context.ArticleCategories.FirstOrDefaultAsync(x => x.Id == id);

            if (articleCategoryModel == null)
            {
                return null;
            }

            _context.ArticleCategories.Remove(articleCategoryModel);
            await _context.SaveChangesAsync();
            return articleCategoryModel;
        }

        //Get all article categories from database
        public async Task<List<ArticleCategory>> GetAllAsync()
        {
            return await _context.ArticleCategories.ToListAsync();
        }
        
        public async Task<ArticleCategory?> GetByIdAsync(int id)
        {
            return await _context.ArticleCategories.FirstOrDefaultAsync(cr => cr.Id == id);
        }

        public async Task<ArticleCategory?> UpdateAsync(int id, ArticleCategory ArticleCategoryModel)
        {
            var existingArticleCategory = await _context.ArticleCategories.FindAsync(id);

            if (existingArticleCategory == null)
            {
                return null;
            }
            existingArticleCategory.Name = ArticleCategoryModel.Name;

            await _context.SaveChangesAsync();

            return existingArticleCategory;
        }
    }
}