namespace AOP.WebAPI.Core.Data.Entities.DataTransferObjects
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class HeadquartersDTO
    {
        public HeadquartersDTO()
        {
            this.Markets = new HashSet<MarketDTO>();
            this.DistributionServers = new HashSet<DistributionServerDTO>();
        }

        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public DateTime? LastUpdated { get; set; }

        public virtual ICollection<MarketDTO> Markets { get; set; }

        public virtual ICollection<DistributionServerDTO> DistributionServers { get; set; }
    }
}
