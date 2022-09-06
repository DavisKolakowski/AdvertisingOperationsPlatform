namespace AOP.WebAPI.Core.Interfaces
{
    using AOP.WebAPI.Core.Data.Entities.Models;

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    public interface IDistributionServerSpotRepository : IRepositoryBase<DistributionServerSpot>
    {
        IEnumerable<DistributionServerSpot> DistributionServerSpotsByServerId(int serverId);
    }
}
