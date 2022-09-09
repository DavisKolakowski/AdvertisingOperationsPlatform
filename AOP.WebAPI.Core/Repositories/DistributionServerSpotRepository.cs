﻿namespace AOP.WebAPI.Core.Repositories
{
    using AOP.WebAPI.Core.Data;
    using AOP.WebAPI.Core.Repositories.Base;
    using Microsoft.EntityFrameworkCore;

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Security.Principal;
    using AOP.WebAPI.Core.Interfaces;
    using AOP.WebAPI.Core.Data.Entities.Models;

    public class DistributionServerSpotRepository : RepositoryBase<DistributionServerSpot>, IDistributionServerSpotRepository
    {
        public DistributionServerSpotRepository(AOPDatabaseContext dbContext)
            : base(dbContext)
        {
        }

        public IEnumerable<DistributionServerSpot> DistributionServerSpotsByServerId(int serverId)
        {
            return FindBy(dss => dss.DistributionServer.Id == serverId)
                .Include(dss => dss.Spot)
                .ToList();
        }
    }
}
