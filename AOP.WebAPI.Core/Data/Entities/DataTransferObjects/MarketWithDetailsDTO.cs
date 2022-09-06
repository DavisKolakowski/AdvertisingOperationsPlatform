namespace AOP.WebAPI.Core.Data.Entities.DataTransferObjects
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    public class MarketWithDetailsDTO
    {
        public MarketWithDetailsDTO()
        {
            this.Market = new MarketDTO();
            this.Headquarters = new List<HeadquartersDTO>();
        }

        public MarketDTO Market { get; set; }

        public IList<HeadquartersDTO> Headquarters { get; set; }
    }
}
