namespace AOP.WebAPI.Models
{
    using AOP.WebAPI.Core.Data.Entities.DataTransferObjects;

    public class MarketWithHeadquartersResponse
    {
        public MarketDTO Market { get; set; }

        public List<HeadquartersDTO> Headquarters { get; set; }
    }
}
