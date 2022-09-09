#nullable disable

using AOP;

namespace AOP.WebAPI.Core.Data.Entities.Models
{
    public class Spot
    {
        public Spot()
        {
            DistributionServerSpots = new List<DistributionServerSpot>();
        }
        public int Id { get; set; }

        public string SpotIdentifier { get; set; }

        public string Name { get; set; }

        public DateTime? LastUpdated { get; set; }

        public virtual IList<DistributionServerSpot> DistributionServerSpots { get; set; }
    }
}
