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

    public class DistributionServerRepository : RepositoryBase<DistributionServer>, IDistributionServerRepository
    {
        public DistributionServerRepository(AOPDatabaseContext dbContext)
            : base(dbContext)
        {

        }

        public async Task<IEnumerable<DistributionServer>> GetAllDistributionServersAsync()
        {
            return await FindAll()
               .OrderBy(ds => ds.ServerIdentity)
               .ToListAsync();
        }

        public async Task<DistributionServer> GetDistributionServerByServerIdentityAsync(string serverIdentity)
        {
            return await FindBy(distributionServer => distributionServer.ServerIdentity == serverIdentity)
                .FirstOrDefaultAsync();
        }

        public async Task<DistributionServer> GetDistributionServerByServerIdAsync(int serverId)
        {
            return await FindBy(distributionServer => distributionServer.Id == serverId)
                .FirstOrDefaultAsync();
        }

        public async Task<DistributionServer> GetDistributionServerWithDetailsAsync(int serverId)
        {
            return await FindBy(distributionServer => distributionServer.Id == serverId)
                    .Include(ds => ds.Headquarters)
                    .Include(ds => ds.DistributionServerSpots)
                        .ThenInclude(dss => dss.Spot)
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Spot>> GetSpotsByDistributionServerAsync(DistributionServer distributionServer)
        {
            return await FindBy(ds => ds == distributionServer)
                        .Include(ds => ds.DistributionServerSpots)
                            .ThenInclude(dss => dss.Spot)
                                .ThenInclude(spot => spot.DistributionServerSpots)
                                    .ThenInclude(dss => dss.DistributionServer)
                        .SelectMany(ds => ds.DistributionServerSpots)
                        .Select(dss => dss.Spot)
                        .Distinct()
                .ToListAsync();
        }

        public void CreateDistributionServer(DistributionServer distributionServer)
        {
            Create(distributionServer);
        }

        public void UpdateDistributionServer(DistributionServer distributionServer)
        {
            Update(distributionServer);
        }

        public void DeleteDistributionServer(DistributionServer distributionServer)
        {
            Delete(distributionServer);
        }
    }
}
