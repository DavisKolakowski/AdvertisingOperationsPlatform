namespace AOP.WebAPI.Core.Interfaces
{
    public interface IRepositoryBaseWrapper
    {
        IMarketRepository Market { get; }

        IHeadquartersRepository Headquarters { get; }

        IDistributionServerRepository DistributionServer { get; }

        Task SaveAsync();
    }
}
