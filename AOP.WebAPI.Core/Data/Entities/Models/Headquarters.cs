#nullable disable

namespace AOP.WebAPI.Core.Data.Entities.Models
{
    public class Headquarters
    {
        public Headquarters()
        {
            Markets = new HashSet<Market>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime? LastUpdated { get; set; }

        public ICollection<DistributionServer> DistributionServers { get; set; }

        public virtual ICollection<Market> Markets { get; set; }
    }
}
