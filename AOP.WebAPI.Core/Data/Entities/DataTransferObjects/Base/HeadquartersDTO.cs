namespace AOP.WebAPI.Core.Data.Entities.DataTransferObjects.Base
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class HeadquartersDTO
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public DateTime? LastUpdated { get; set; }

        public int[]? MarketIds { get; set; }

        public DistributionServerDTO[]? DistributionServers { get; set; }
    }
}
