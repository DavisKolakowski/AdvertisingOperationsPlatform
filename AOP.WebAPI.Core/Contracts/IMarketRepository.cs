namespace AOP.WebAPI.Core.Contracts
{
    using AOP.WebAPI.Core.Data.Entities.Models;
    using AOP.WebAPI.Core.Interfaces;

    public interface IMarketRepository : IRepositoryBase<Market>
    {
        Task<IEnumerable<Market>> GetAllMarketsAsync();

        Task<Market> GetMarketByNameAsync(string marketName);

        Task<Market> GetMarketWithDetailsAsync(string marketName);

        void CreateMarket(Market market);

        void UpdateMarket(Market market);

        void DeleteMarket(Market market);
    }
}
