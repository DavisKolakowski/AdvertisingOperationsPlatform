namespace AOP.WebAPI.Core.Interfaces
{
    using AOP.WebAPI.Core.Contracts;
    public interface IRepositoryBaseWrapper
    {
        IMarketRepository Market { get; }

        Task SaveAsync();
    }
}
