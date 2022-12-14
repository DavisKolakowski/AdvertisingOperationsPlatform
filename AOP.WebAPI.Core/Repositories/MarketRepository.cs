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

    public class MarketRepository : RepositoryBase<Market>, IMarketRepository
    {
        public MarketRepository(AOPDatabaseContext dbContext)
            : base(dbContext)
        {

        }

        public async Task<IEnumerable<Market>> GetAllMarketsAsync()
        {
            return await FindAll()
               .OrderBy(m => m.Name)
               .ToListAsync();
        }

        public async Task<Market> GetMarketByNameAsync(string marketName)
        {
            return await FindBy(market => market.Name == marketName)
                .FirstOrDefaultAsync();
        }

        public async Task<Market> GetMarketByIdAsync(int marketId)
        {
            return await FindBy(market => market.Id == marketId)
                .FirstOrDefaultAsync();
        }

        public async Task<Market> GetMarketWithDetailsAsync(int marketId)
        {
            return await FindBy(market => market.Id == marketId)
                    .Include(m => m.Headquarters)
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Spot>> GetSpotsByMarketAsync(Market market)
        {
            return await FindBy(m => m == market)
                .Include(m => m.Headquarters)
                    .ThenInclude(hq => hq.DistributionServers)
                        .ThenInclude(ds => ds.DistributionServerSpots)
                            .ThenInclude(dss => dss.Spot)
                                .ThenInclude(spot => spot.DistributionServerSpots)
                                    .ThenInclude(dss => dss.DistributionServer)
                        .SelectMany(m => m.Headquarters)
                        .SelectMany(hq => hq.DistributionServers)
                        .SelectMany(ds => ds.DistributionServerSpots)
                        .Select(dss => dss.Spot)
                        .Distinct()
                .ToListAsync();
        }

        public void CreateMarket(Market market)
        {
            Create(market);
        }

        public void UpdateMarket(Market market)
        {
            Update(market);
        }

        public void DeleteMarket(Market market)
        {
            Delete(market);
        }
    }
}
