namespace AOP.WebAPI.Models
{
    using AOP.WebAPI.Core.Data.Entities.DataTransferObjects;

    public class MarketWithSpotCountResponse
    {
        public MarketDTO Market { get; set; }

        public int MarketSpotCount { get; set; }
    }
}
