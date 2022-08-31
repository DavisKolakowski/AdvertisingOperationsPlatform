namespace AOP.WebAPI.Core.Data.Entities.DataTransferObjects
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class DistributionServerSpotDTO
    {
        public int Id { get; set; }

        public DateTime? FirstAirDate { get; set; }

        public SpotDTO Spot { get; set; }
    }
}
