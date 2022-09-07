namespace AOP.WebAPI.Core.Data.Entities.DataTransferObjects
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class HeadquartersForMarketWithDetailsDTO
    {
        public HeadquartersForMarketWithDetailsDTO()
        {
            this.DistributionServers = new HashSet<DistributionServerDTO>();
        }

        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public DateTime? LastUpdated { get; set; }

        public virtual ICollection<DistributionServerDTO> DistributionServers { get; set; }
    }
}
