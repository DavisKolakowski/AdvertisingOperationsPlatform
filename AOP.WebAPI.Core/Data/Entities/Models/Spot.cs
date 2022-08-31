#nullable disable

namespace AOP.WebAPI.Core.Data.Entities.Models
{
    public class Spot
    {
        public int Id { get; set; }

        public string SpotIdentifier { get; set; }

        public string Name { get; set; }

        public DateTime? LastUpdated { get; set; }

        public List<DistributionServerSpot> DistributionServerSpots { get; set; } = new List<DistributionServerSpot>();
    }
}
