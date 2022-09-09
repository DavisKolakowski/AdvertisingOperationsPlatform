#nullable disable

using AOP;

namespace AOP.WebAPI.Core.Data.Entities.Models
{
    public class Headquarters
    {
        public Headquarters()
        {
            Markets = new HashSet<Market>();
            DistributionServers = new HashSet<DistributionServer>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime? LastUpdated { get; set; }

        public virtual ICollection<Market> Markets { get; set; }

        public virtual ICollection<DistributionServer> DistributionServers { get; set; }
    }
}
