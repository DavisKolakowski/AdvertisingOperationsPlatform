namespace AOP.WebAPI.Core.Data.Entities.DataTransferObjects
{
    using AOP.WebAPI.Core.Data.Entities.Models;

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class SpotDTO
    {
        public int Id { get; set; }

        public string SpotIdentifier { get; set; } = string.Empty;

        public string Name { get; set; } = string.Empty;
    }
}
