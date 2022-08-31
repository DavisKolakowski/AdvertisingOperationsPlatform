#nullable disable

namespace AOP.WebAPI.Core.Data.Entities.Models
{
    public class DistributionServerSpot
    {
        public int Id { get; set; }

        public Spot Spot { get; set; }

        public DateTime? FirstAirDate { get; set; }

        public DateTime? LastUpdated { get; set; }

        public DistributionServer DistributionServer { get; set; }
    }
}
