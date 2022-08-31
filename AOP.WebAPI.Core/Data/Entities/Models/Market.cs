#nullable disable

namespace AOP.WebAPI.Core.Data.Entities.Models
{
    public class Market
    {
        public Market()
        {
            Headquarters = new HashSet<Headquarters>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime? LastUpdated { get; set; }

        public virtual ICollection<Headquarters> Headquarters { get; set; }
    }
}
