namespace AOP.WebAPI
{
    using AOP.WebAPI.Core.Data.Entities.DataTransferObjects;
    using AOP.WebAPI.Core.Data.Entities.DataTransferObjects.Base;
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
            CreateMap<Market, MarketDTO>()
                .ForMember(obj => obj.HeadquartersIds, options =>
                    options.MapFrom(m => m.Headquarters.Select(hq => hq.Id).ToArray()));

            CreateMap<Headquarters, HeadquartersDTO>()
                .ForMember(obj => obj.MarketIds, options =>
                    options.MapFrom(hq => hq.Markets.Select(m => m.Id).ToArray()))
                .ForMember(obj => obj.DistributionServers, options =>
                    options.MapFrom(hq => hq.DistributionServers));

            CreateMap<DistributionServer, DistributionServerDTO>()
                .ForMember(obj => obj.HeadquartersId, options =>
                    options.MapFrom(ds => ds.Headquarters.Id));

            CreateMap<DistributionServerSpot, DistributionServerSpotDTO>()
                .ForMember(obj => obj.DistributionServerId, options =>
                    options.MapFrom(dss => dss.DistributionServer.Id))
                .ForMember(obj => obj.SpotId, options =>
                    options.MapFrom(dss => dss.Spot.Id));

            CreateMap<Spot, SpotDTO>()
                .ForMember(obj => obj.DistributionServerSpots, options =>
                    options.MapFrom(s => s.DistributionServerSpots));
        }
    }
}
