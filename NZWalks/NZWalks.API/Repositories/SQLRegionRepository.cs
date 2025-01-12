﻿using Microsoft.EntityFrameworkCore;
using NZWalks.API.Data;
using NZWalks.API.Models.Domain;

namespace NZWalks.API.Repositories
{
    public class SQLRegionRepository : IRegionRepository
    {
        private readonly NZWalksDBContext dBContext;

        public SQLRegionRepository(NZWalksDBContext dBContext)
        {
            this.dBContext = dBContext;
        }
        public async Task<List<Region>> GetAllAsync()
        {
            return await dBContext.Regions.ToListAsync();
        }

        public async Task<Region?> GetByIdAsync(Guid id)
        {
            return await dBContext.Regions.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Region?> CreateAsync(Region region)
        {
            await dBContext.Regions.AddAsync(region);
            await dBContext.SaveChangesAsync();
            return region;

        }

        public async Task<Region?> UpdateAsync(Guid id, Region region)
        {
            var existingRegion = await dBContext.Regions.FirstOrDefaultAsync(x => x.Id == id);
            if (existingRegion == null)
            {
                return null;
            }
            existingRegion.Code = region.Code;
            existingRegion.Name = region.Name;
            existingRegion.RegionImageUrl = region.RegionImageUrl;

            await dBContext.SaveChangesAsync();
            return existingRegion;
        }

        public async Task<Region?> DeleteAsync(Guid id)
        {
            var existingregion = await dBContext.Regions.FirstOrDefaultAsync(x => x.Id == id);
            if (existingregion == null)
            {
                return null;
            }
            dBContext.Regions.Remove(existingregion);
            await dBContext.SaveChangesAsync();
            return existingregion;
        }
    }
}
