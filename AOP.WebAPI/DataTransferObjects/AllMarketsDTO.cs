namespace AOP.WebAPI.DataTransferObjects
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    public class AllMarketsDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime? LastUpdated { get; set; }

        public int SpotsInMarketCount { get; set; }
    }
}
