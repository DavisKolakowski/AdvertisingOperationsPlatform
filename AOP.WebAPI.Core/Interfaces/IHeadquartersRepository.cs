namespace AOP.WebAPI.Core.Interfaces
{
    using AOP.WebAPI.Core.Data.Entities.Models;

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
