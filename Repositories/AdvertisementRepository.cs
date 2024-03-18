using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Data;
using Backend.Dtos.Advertisement;
using Backend.QueryObjects;
using Backend.Interfaces;
using Backend.Models;
using Microsoft.EntityFrameworkCore;
using Backend.Mappers;
//
namespace Backend.Repositories
{
    public class AdvertisementRepository : IAdvertisementRepository
    {
        private readonly ApplicationDbContext _context;
        public AdvertisementRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Advertisement?> CreateAsync(Advertisement advertisementModel)
        {
            await _context.Advertisements.AddAsync(advertisementModel);
            await _context.SaveChangesAsync();
            return advertisementModel;
        }

        public async Task<Advertisement?> DeleteAsync(int id)
        {
            var advertisementModel = await _context.Advertisements.FirstOrDefaultAsync(x => x.Id == id);

            if (advertisementModel == null)
            {
                return null;
            }

            _context.Advertisements.Remove(advertisementModel);
            await _context.SaveChangesAsync();
            return advertisementModel;
        }

        public async Task<List<Advertisement>> GetAllAsync(AdvertisementQueryObject query)
        {
            //After adding Marketing Team Member should be implemented Include(a => a.MarketingTeamMember).AsQueryable();
            var advertisements = _context.Advertisements.AsQueryable();

            if (!string.IsNullOrWhiteSpace(query.SortBy))
            {
                if (query.SortBy.Equals("StartDate", StringComparison.OrdinalIgnoreCase))
                {
                    advertisements = query.IsDecsending ? advertisements.OrderByDescending(s => s.StartDate) : advertisements.OrderBy(s => s.StartDate);
                }
                else if(query.SortBy.Equals("NumberOfDays", StringComparison.OrdinalIgnoreCase)) {
                    advertisements = query.IsDecsending ? advertisements.OrderByDescending(s => s.NumberOfDays) : advertisements.OrderBy(s => s.NumberOfDays);
                }
                else if(query.SortBy.Equals("Price", StringComparison.OrdinalIgnoreCase)) {
                    advertisements = query.IsDecsending ? advertisements.OrderByDescending(s => s.Price) : advertisements.OrderBy(s => s.Price);
                }
            }



            return await advertisements.ToListAsync();
        }

        public async Task<Advertisement?> GetByIdAsync(int id)
        {
            ////After adding Marketing Team Member should be implemented Include(a => a.MarketingTeamMember)
            return await _context.Advertisements.FirstOrDefaultAsync(i => i.Id == id);
        }

        //public async Task<Advertisement?> GetByMarketingTeamMemberAsync(string title)
        //{
        //    return await _context.Advertisements.FirstOrDefaultAsync(s => s.Title == title);
        //}

        public Task<bool> AdvertisementExists(int id)
        {
            return _context.Advertisements.AnyAsync(s => s.Id == id);
        }

        public async Task<Advertisement?> UpdateAsync(int id, AdvertisementDto advertisementDto)
        {
            var existingAdvertisement = await _context.Advertisements.FirstOrDefaultAsync(x => x.Id == id);

            if (existingAdvertisement == null)
            {
                return null;
            }
            existingAdvertisement = advertisementDto.ToAdvertisementFromCreateDTO();

            await _context.SaveChangesAsync();

            return existingAdvertisement;
        }
    }
}