namespace AOP.WebAPI.Core.Data.Entities.DataTransferObjects
{
    using AOP.WebAPI.Core.Data.Entities.DataTransferObjects.Base;

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class MarketByNameWithHeadquartersDTO
    {
        public MarketDTO Market { get; set; }

        public string[] HeadquartersName { get; set; }
    }
}
