using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Dtos.Advertisement;
using Backend.Interfaces;
using Backend.Models;
using Backend.QueryObjects;

namespace Backend.Interfaces
{
    public interface IAdvertisementRepository
    {
        Task<List<Advertisement>> GetAllAsync(AdvertisementQueryObject query);
        
        Task<Advertisement?> GetByIdAsync(int id);
        
        //Will be implemented after implementing MarketingTeamMember  
        //Task<Advertisement?> GetByMarketingTeamMemberIdAsync(int id);
        
        Task<Advertisement> CreateAsync(Advertisement advertisementModel);
        
        Task<Advertisement?> UpdateAsync(int id, AdvertisementDto advertisementDto);
        
        Task<Advertisement?> DeleteAsync(int id);
        
        Task<bool> AdvertisementExists(int id);
    }
}