#nullable disable

namespace AOP.WebAPI.Core.Data
{
    using AOP.WebAPI.Core.Data.Entities.Models;
    using Microsoft.EntityFrameworkCore;

    public class AOPDatabaseContext : DbContext
    {
        public AOPDatabaseContext()
            : base()
        {

        }

        public AOPDatabaseContext(DbContextOptions<AOPDatabaseContext> options)
            : base(options)
        {
           
        }

        public DbSet<Market> Markets { get; set; }

        public DbSet<Headquarters> Headquarters { get; set; }

        public DbSet<DistributionServer> DistributionServers { get; set; }

        public DbSet<DistributionServerSpot> DistributionServerSpots { get; set; }

        public DbSet<Spot> Spots { get; set; }
    }
}