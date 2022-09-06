namespace AOP.WebAPI.Core.Data.Entities.DataTransferObjects
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    public class HeadquartersWithDetailsDTO
    {
        public HeadquartersDTO HeadquartersDTO { get; set; }

        public IList<MarketDTO> Markets { get; set; }
    }
}
