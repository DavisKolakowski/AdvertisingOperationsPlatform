namespace AOP.WebAPI.Core.Data.Entities.DataTransferObjects
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    public class MarketDTO
    {
        public MarketDTO()
        {
            this.Headquarters = new HashSet<HeadquartersDTO>();
        }

        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public DateTime? LastUpdated { get; set; }

        public virtual ICollection<HeadquartersDTO> Headquarters { get; set; }
    }
}
