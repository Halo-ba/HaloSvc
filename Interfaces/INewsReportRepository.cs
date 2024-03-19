using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Dtos.NewsReport;
using Backend.Interfaces;
using Backend.Models;
using Backend.QueryObjects;

namespace Backend.Interfaces
{
    public interface INewsReportRepository
    {
        Task<List<NewsReport>> GetAllAsync(NewsReportQueryObject query);

        Task<NewsReport?> GetByIdAsync(int id);

        //Will be implemented after implementing MarketingTeamMember  
        //Task<NewsReport?> GetByMarketingTeamMemberIdAsync(int id);

        Task<NewsReport> CreateAsync(NewsReport newsReportModel);

        Task<NewsReport?> UpdateAsync(int id, NewsReportDto newsReportDto);

        Task<NewsReport?> DeleteAsync(int id);

        Task<bool> NewsReportExists(int id);
    }
}