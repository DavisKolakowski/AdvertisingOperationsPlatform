namespace AOP.WebAPI.Core.Data.Entities.DataTransferObjects.Base
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class DistributionServerSpotDTO
    {
        public int Id { get; set; }

        public int SpotId { get; set; }

        public DateTime? FirstAirDate { get; set; }

        public DateTime? LastUpdated { get; set; }

        public int DistributionServerId { get; set; }
    }
}
