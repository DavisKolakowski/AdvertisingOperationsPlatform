﻿namespace AOP.WebAPI.Core.Data.Entities
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

            CreateMap<DistributionServerSpot, DistributionServerSpotDTO>();

            CreateMap<Spot, SpotDTO>();



            CreateMap<Market, AllMarketsDTO>();

            CreateMap<Market, MarketByNameDTO>();

            CreateMap<Market, MarketWithDetailsDTO>()
                .ForMember(dto => dto.Market, options => 
                    options.MapFrom(m => m.Headquarters));

            CreateMap<Headquarters, HeadquartersWithDetailsDTO>();


            CreateMap<DistributionServer, DistributionServerDetailsDTO>();
        }
    }
}