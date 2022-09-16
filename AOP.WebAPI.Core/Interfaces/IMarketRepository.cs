namespace AOP.WebAPI.Core.Interfaces
{
    using AOP.WebAPI.Core.Data.Entities.Models;

    public interface IMarketRepository : IRepositoryBase<Market>
    {
        Task<IEnumerable<Market>> GetAllMarketsAsync();

        Task<Market> GetMarketByNameAsync(string marketName);

        Task<Market> GetMarketByIdAsync(int marketId);        

        Task<Market> GetMarketWithDetailsAsync(int marketId);

        Task<IEnumerable<Spot>> GetSpotsByMarketAsync(Market market);      

        void CreateMarket(Market market);

        void UpdateMarket(Market market);

        void DeleteMarket(Market market);
    }
}
