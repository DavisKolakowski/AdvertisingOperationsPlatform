namespace AOP.WebAPI.Core.Repositories
{
    using AOP.WebAPI.Core.Data;
    using AOP.WebAPI.Core.Repositories.Base;
    using Microsoft.EntityFrameworkCore;

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using AOP.WebAPI.Core.Interfaces;
    using AOP.WebAPI.Core.Data.Entities.Models;

    public class HeadquartersRepository : RepositoryBase<Headquarters>, IHeadquartersRepository
    {
        public HeadquartersRepository(AOPDatabaseContext dbContext)
            : base(dbContext)
        {

        }

        public async Task<IEnumerable<Headquarters>> GetAllHeadquartersAsync()
        {
            return await FindAll()
               .OrderBy(hq => hq.Name)
               .ToListAsync();
        }

        public async Task<Headquarters> GetHeadquartersByNameAsync(string headquartersName)
        {
            return await FindBy(headquarters => headquarters.Name == headquartersName)
                .FirstOrDefaultAsync();
        }

        public async Task<Headquarters> GetHeadquartersByIdAsync(int headquartersId)
        {
            return await FindBy(headquarters => headquarters.Id == headquartersId)
                .FirstOrDefaultAsync();
        }

        public async Task<Headquarters> GetHeadquartersWithDetailsAsync(int headquartersId)
        {
            return await FindBy(headquarters => headquarters.Id == headquartersId)
                    .Include(hq => hq.Markets)
                    .Include(hq => hq.DistributionServers)
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Spot>> GetSpotsByHeadquartersAsync(Headquarters headquarters)
        {
            return await FindBy(hq => hq == headquarters)
                    .Include(hq => hq.DistributionServers)
                        .ThenInclude(ds => ds.DistributionServerSpots)
                            .ThenInclude(dss => dss.Spot)
                                .ThenInclude(spot => spot.DistributionServerSpots)
                                    .ThenInclude(dss => dss.DistributionServer)
                        .SelectMany(hq => hq.DistributionServers)
                        .SelectMany(ds => ds.DistributionServerSpots)
                        .Select(dss => dss.Spot)
                        .Distinct()
                .ToListAsync();
        }

        public void CreateHeadquarters(Headquarters headquarters)
        {
            Create(headquarters);
        }

        public void UpdateHeadquarters(Headquarters headquarters)
        {
            Update(headquarters);
        }

        public void DeleteHeadquarters(Headquarters headquarters)
        {
            Delete(headquarters);
        }
    }
}
