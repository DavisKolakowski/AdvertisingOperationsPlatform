namespace AOP.WebAPI.Core.Interfaces
{
    using AOP.WebAPI.Core.Data.Entities.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface IDistributionServerRepository : IRepositoryBase<DistributionServer>
    {
        Task<IEnumerable<DistributionServer>> GetAllDistributionServersAsync();

        Task<DistributionServer> GetDistributionServerByServerIdentityAsync(string serverIdentity);

        Task<DistributionServer> GetDistributionServerByServerIdAsync(int serverId);

        Task<DistributionServer> GetDistributionServerWithDetailsAsync(int serverId);

        Task<IEnumerable<Spot>> GetSpotsByDistributionServerAsync(DistributionServer distributionServer);

        void CreateDistributionServer(DistributionServer headquarters);

        void UpdateDistributionServer(DistributionServer headquarters);

        void DeleteDistributionServer(DistributionServer headquarters);
    }
}
