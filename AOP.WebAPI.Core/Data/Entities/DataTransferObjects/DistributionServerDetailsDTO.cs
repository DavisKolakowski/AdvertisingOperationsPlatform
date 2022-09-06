namespace AOP.WebAPI.Core.Data.Entities.DataTransferObjects
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class DistributionServerDetailsDTO
    {
        public int Id { get; set; }

        public string ServerIdentity { get; set; }

        public string ServerFolder { get; set; }

        public DateTime? LastUpdated { get; set; }

        public DateTime? LastSuccessfulDatabaseJob { get; set; }

        public string SpotsLogFileName { get; set; } = string.Empty;

        public DateTime? SpotsLogLastWriteTime { get; set; }

        public DistributionServerHeadquartersDTO Headquarters { get; set; }

        public IList<DistributionServerSpotDTO> Spots { get; set; }
    }
}
