namespace AOP.WebAPI.Core.Data.Entities
{
    using AOP.WebAPI.Core.Data.Entities.DataTransferObjects;
    using AOP.WebAPI.Core.Data.Entities.Models;

    using AutoMapper;

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Market, MarketDTO>();

            CreateMap<Headquarters, HeadquartersDTO>();

            CreateMap<DistributionServer, DistributionServerDTO>();

            CreateMap<Spot, SpotDTO>()
                .ForMember(dto => dto.FirstAirDate, options =>
                    options.MapFrom(s => s.DistributionServerSpots
                        .OrderBy(dss => dss.FirstAirDate)
                            .First().FirstAirDate));
        }
    }
}
