namespace AOP.WebAPI.Core.Data.Entities.DataTransferObjects
{
    using AOP.WebAPI.Core.Data.Entities.Models;

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class DistributionServerDTO
    {
        public DistributionServerDTO()
        {
            this.DistributionServerSpots = new List<DistributionServerSpotDTO>();
        }

        public int Id { get; set; }

        public string ServerIdentity { get; set; } = string.Empty;

        public string ServerFolder { get; set; } = string.Empty;

        public int? HeadquartersId { get; set; }

        public DateTime? LastUpdated { get; set; }

        public DateTime? LastSuccessfulDatabaseJob { get; set; }

        public string SpotsLogFileName { get; set; } = string.Empty;

        public DateTime? SpotsLogLastWriteTime { get; set; }

        public virtual IList<DistributionServerSpotDTO> DistributionServerSpots { get; set; }
    }
}
