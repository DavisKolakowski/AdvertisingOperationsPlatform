namespace AOP.WebAPI.Core.Interfaces
{
    public interface IRepositoryBaseWrapper
    {
        IMarketRepository Market { get; }

        Task SaveAsync();
    }
}
