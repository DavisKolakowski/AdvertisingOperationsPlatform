namespace AOP.WebAPI.Core.Contracts
{
    using AOP.WebAPI.Core.Data.Entities.Models;
    using AOP.WebAPI.Core.Interfaces;

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface IDistributionServerRepository : IRepositoryBase<DistributionServer>
    {
        Task<IEnumerable<DistributionServer>> GetAllDistributionServersAsync();

        Task<DistributionServer> GetDistributionServerByServerIdentityAsync(string serverIdentity);

        Task<DistributionServer> GetDistributionServerWithDetailsAsync(string serverIdentity);

        void CreateDistributionServer(DistributionServer headquarters);

        void UpdateDistributionServer(DistributionServer headquarters);

        void DeleteDistributionServer(DistributionServer headquarters);
    }
}
