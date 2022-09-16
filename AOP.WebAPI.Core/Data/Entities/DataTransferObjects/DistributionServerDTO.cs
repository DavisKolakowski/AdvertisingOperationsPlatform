namespace AOP.WebAPI.Core.Data.Entities.DataTransferObjects
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class DistributionServerDTO
    {
        public int Id { get; set; }

        public string? ServerIdentity { get; set; }

        public string? ServerFolder { get; set; }

        public DateTime? LastUpdated { get; set; }

        public DateTime? LastSuccessfulDatabaseJob { get; set; }

        public string? SpotsLogFileName { get; set; }

        public DateTime? SpotsLogLastWriteTime { get; set; }
    }
}
