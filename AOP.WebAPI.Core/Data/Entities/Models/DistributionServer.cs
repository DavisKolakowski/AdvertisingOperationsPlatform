#nullable disable

namespace AOP.WebAPI.Core.Data.Entities.Models
{
    public class DistributionServer
    {
        public DistributionServer()
        {
            DistributionServerSpots = new List<DistributionServerSpot>();
        }

        public int Id { get; set; }

        public string ServerIdentity { get; set; }

        public string ServerFolder { get; set; }

        public int? HeadquartersId { get; set; }

        public virtual Headquarters Headquarters { get; set; }

        public DateTime? LastUpdated { get; set; }

        public DateTime? LastSuccessfulDatabaseJob { get; set; }

        public string SpotsLogFileName { get; set; } = string.Empty;

        public DateTime? SpotsLogLastWriteTime { get; set; }

        public virtual IList<DistributionServerSpot> DistributionServerSpots { get; set; }
    }
}
