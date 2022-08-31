namespace AOP.WebAPI.Core.Repositories.Base
{
    using AOP.WebAPI.Core.Contracts;
    using AOP.WebAPI.Core.Data;
    using AOP.WebAPI.Core.Interfaces;

    public class RepositoryBaseWrapper : IRepositoryBaseWrapper
    {
        private AOPDatabaseContext _dbContext;

        private IMarketRepository _market;

        private IHeadquartersRepository _headquarters;

        private IDistributionServerRepository _distributionServer;

        public IMarketRepository Market
        {
            get
            {
                if (this._market == null)
                {
                    this._market = new MarketRepository(this._dbContext);
                }
                return this._market;
            }
        }

        public IHeadquartersRepository Headquarters
        {
            get
            {
                if (this._headquarters == null)
                {
                    this._headquarters = new HeadquartersRepository(this._dbContext);
                }
                return this._headquarters;
            }
        }

        public IDistributionServerRepository DistributionServer
        {
            get
            {
                if (this._distributionServer == null)
                {
                    this._distributionServer = new DistributionServerRepository(this._dbContext);
                }
                return this._distributionServer;
            }
        }

        public RepositoryBaseWrapper(AOPDatabaseContext dbContext)
        {
            _dbContext = dbContext;
            _market = this.Market;
            _headquarters = this.Headquarters;
            _distributionServer = this.DistributionServer;
        }

        public async Task SaveAsync()
        {
            await this._dbContext.SaveChangesAsync();
        }
    }
}
