#nullable disable

namespace AOP.WebAPI.Core.Data.Entities.Models
{
    public class DistributionServer
    {
        public int Id { get; set; }

        public string ServerIdentity { get; set; }

        public string ServerFolder { get; set; }

        public int? HeadquartersId { get; set; }

        public Headquarters Headquarters { get; set; }

        public DateTime? LastUpdated { get; set; }

        public DateTime? LastSuccessfulDatabaseJob { get; set; }

        public string SpotsLogFileName { get; set; } = string.Empty;

        public DateTime? SpotsLogLastWriteTime { get; set; }

        public List<DistributionServerSpot> DistributionServerSpots { get; set; } = new List<DistributionServerSpot>();
    }
}
