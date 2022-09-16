namespace AOP.WebAPI.Models
{
    using AOP.WebAPI.Core.Data.Entities.DataTransferObjects;

    public class MarketWithSpotsResponse
    {
        public MarketDTO Market { get; set; }

        public List<SpotDTO> SpotsInMarket { get; set; }
    }
}
