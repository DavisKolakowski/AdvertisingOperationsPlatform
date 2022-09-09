#nullable disable

using AOP;

namespace AOP.WebAPI.Core.Data.Entities.Models
{
    public class DistributionServerSpot
    {
        public int Id { get; set; }

        public virtual Spot Spot { get; set; }

        public DateTime? FirstAirDate { get; set; }

        public DateTime? LastUpdated { get; set; }

        public virtual DistributionServer DistributionServer { get; set; }
    }
}
