namespace AOP.WebAPI.Core.Interfaces
{
    using AOP.WebAPI.Core.Data.Entities.Models;

    public interface IHeadquartersRepository : IRepositoryBase<Headquarters>
    {
        Task<IEnumerable<Headquarters>> GetAllHeadquartersAsync();

        Task<Headquarters> GetHeadquartersByNameAsync(string headquartersName);

        Task<Headquarters> GetHeadquartersByIdAsync(int headquartersId);

        Task<Headquarters> GetHeadquartersWithDetailsAsync(int headquartersId);

        Task<IEnumerable<Spot>> GetSpotsByHeadquartersAsync(Headquarters headquarters);

        void CreateHeadquarters(Headquarters headquarters);

        void UpdateHeadquarters(Headquarters headquarters);

        void DeleteHeadquarters(Headquarters headquarters);
    }
}
