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
    public class CommentReportRepository : ICommentReportRepository
    {
        private readonly ApplicationDbContext _context;
        public CommentReportRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<CommentReport> CreateAsync(CommentReport commentReportModel)
        {
            await _context.CommentReports.AddAsync(commentReportModel);
            await _context.SaveChangesAsync();
            return commentReportModel;
        }

        public async Task<CommentReport?> DeleteAsync(int id)
        {
            var commentReportModel = await _context.CommentReports.FirstOrDefaultAsync(x => x.Id == id);

            if (commentReportModel == null)
            {
                return null;
            }

            _context.CommentReports.Remove(commentReportModel);
            await _context.SaveChangesAsync();
            return commentReportModel;
        }

        //Get all comment reports from database
        public async Task<List<CommentReport>> GetAllAsync()
        {
            return await _context.CommentReports.ToListAsync();
        }

        //Get all comment reports from database for specific comment
        public async Task<List<CommentReport>> GetCommentReportsByCommentIdAsync(int commentId)
        {
            return await _context.CommentReports
                .Where(cr => cr.CommentId == commentId)
                .ToListAsync();
        }
        public async Task<CommentReport?> GetByIdAsync(int id)
        {
            return await _context.CommentReports.FirstOrDefaultAsync(cr => cr.Id == id);
        }

        public async Task<CommentReport?> UpdateAsync(int id, CommentReport commentReportModel)
        {
            var existingCommentReport = await _context.CommentReports.FindAsync(id);

            if (existingCommentReport == null)
            {
                return null;
            }
            existingCommentReport.ReportDescription = commentReportModel.ReportDescription;

            await _context.SaveChangesAsync();

            return existingCommentReport;
        }
    }
}