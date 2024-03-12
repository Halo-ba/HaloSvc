using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Data;
using Backend.Dtos.NewsReport;
using Backend.QueryObjects;
using Backend.Interfaces;
using Backend.Models;
using Microsoft.EntityFrameworkCore;
using Backend.Mappers;

namespace Backend.Repositories
{
    public class NewsReportRepository : INewsReportRepository
    {
        private readonly ApplicationDbContext _context;
        public NewsReportRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<NewsReport?> CreateAsync(NewsReport newsReportModel)
        {
            await _context.NewsReports.AddAsync(newsReportModel);
            await _context.SaveChangesAsync();
            return newsReportModel;
        }

        public async Task<NewsReport?> DeleteAsync(int id)
        {
            var newsReportModel = await _context.NewsReports.FirstOrDefaultAsync(x => x.Id == id);

            if (newsReportModel == null)
            {
                return null;
            }

            _context.NewsReports.Remove(newsReportModel);
            await _context.SaveChangesAsync();
            return newsReportModel;
        }

        public async Task<List<NewsReport>> GetAllAsync(NewsReportQueryObject query)
        {
            //After adding Marketing Team Member should be implemented Include(a => a.MarketingTeamMember).AsQueryable();
            var NewsReports = _context.NewsReports.AsQueryable();

            if (!string.IsNullOrWhiteSpace(query.SortBy))
            {
                if (query.SortBy.Equals("DateOfReport", StringComparison.OrdinalIgnoreCase))
                {
                    NewsReports = query.IsDecsending ? NewsReports.OrderByDescending(s => s.DateOfReport) : NewsReports.OrderBy(s => s.DateOfReport);
                }
            }

            return await NewsReports.ToListAsync();
        }

        public async Task<NewsReport?> GetByIdAsync(int id)
        {
            ////After adding Marketing Team Member should be implemented Include(a => a.MarketingTeamMember)
            return await _context.NewsReports.FirstOrDefaultAsync(i => i.Id == id);
        }

        //Will be implemented when MarketingTeamMember will be...
        //public async Task<NewsReport?> GetByMarketingTeamMemberAsync(string title)
        //{
        //    return await _context.NewsReports.FirstOrDefaultAsync(s => s.Title == title);
        //}

        public Task<bool> NewsReportExists(int id)
        {
            return _context.NewsReports.AnyAsync(s => s.Id == id);
        }

        public async Task<NewsReport?> UpdateAsync(int id, NewsReportDto newsReportDto)
        {
            var existingNewsReport = await _context.NewsReports.FirstOrDefaultAsync(x => x.Id == id);

            if (existingNewsReport == null)
            {
                return null;
            }
            existingNewsReport = newsReportDto.ToNewsReportFromCreateDTO();

            await _context.SaveChangesAsync();

            return existingNewsReport;
        }
    }
}