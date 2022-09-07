﻿namespace AOP.WebAPI.Core.Data.Entities.DataTransferObjects
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    public class MarketWithDetailsDTO
    {
        public MarketWithDetailsDTO()
        {
            this.Headquarters = new HashSet<HeadquartersForMarketWithDetailsDTO>();
        }

        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public DateTime? LastUpdated { get; set; }

        public virtual ICollection<HeadquartersForMarketWithDetailsDTO> Headquarters { get; set; }
    }
}
