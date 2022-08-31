namespace AOP.WebAPI.Core.Contracts
{
    using AOP.WebAPI.Core.Data.Entities.Models;
    using AOP.WebAPI.Core.Interfaces;
    public interface IHeadquartersRepository : IRepositoryBase<Headquarters>
    {
        Task<IEnumerable<Headquarters>> GetAllHeadquartersAsync();

        Task<Headquarters> GetHeadquartersByNameAsync(string headquartersName);

        Task<Headquarters> GetHeadquartersWithDetailsAsync(string headquartersName);

        void CreateHeadquarters(Headquarters headquarters);

        void UpdateHeadquarters(Headquarters headquarters);

        void DeleteHeadquarters(Headquarters headquarters);
    }
}
