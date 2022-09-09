namespace AOP.WebAPI.Core.Data.Entities.DataTransferObjects
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class SpotDTO
    {
        public int Id { get; set; }

        public string? SpotIdentifier { get; set; }

        public string? Name { get; set; }

        public DistributionServerSpotDTO[]? DistributionServerSpots { get; set; }
    }
}
