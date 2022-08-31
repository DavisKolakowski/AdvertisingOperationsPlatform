namespace AOP.WebAPI.Core.Repositories
{
    using AOP.WebAPI.Core.Contracts;
    using AOP.WebAPI.Core.Data;
    using AOP.WebAPI.Core.Repositories.Base;
    using Microsoft.EntityFrameworkCore;

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
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

        public async Task<DistributionServer> GetDistributionServerWithDetailsAsync(string serverIdentity)
        {
            return await FindBy(distributionServer => distributionServer.ServerIdentity == serverIdentity)
                    .Include(ds => ds.Headquarters)
                    .Include(ds => ds.DistributionServerSpots)
                        .ThenInclude(dss => dss.Spot)
                .FirstOrDefaultAsync();
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
