namespace AOP.WebAPI.Core.Data.Entities.DataTransferObjects
{
    using AOP.WebAPI.Core.Data.Entities.Models;

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class DistributionServerSpotDTO
    {
        public DistributionServerSpotDTO()
        {
            this.Spot = new SpotDTO();
        }

        public int Id { get; set; }        

        public DateTime? FirstAirDate { get; set; }

        public virtual SpotDTO Spot { get; set; }
    }
}
