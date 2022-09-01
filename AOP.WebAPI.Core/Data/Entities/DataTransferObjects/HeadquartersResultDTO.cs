﻿namespace AOP.WebAPI.Core.Data.Entities.DataTransferObjects
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class HeadquartersDetailsDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public IEnumerable<MarketDTO> Markets { get; set; }

        public DateTime? LastUpdated { get; set; }

        public IEnumerable<DistributionServerDTO> DistributionServers { get; set; }
    }
}