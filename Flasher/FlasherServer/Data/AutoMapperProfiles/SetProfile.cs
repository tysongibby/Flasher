using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FlasherData.Models;
using FlasherServer.Data.Dtos;

namespace FlasherServer.Data.AutoMapperProfiles
{
    public class SetProfile : Profile
    {
        public SetProfile()
        {
            CreateMap<SetModel, Set>()
                .ForMember(destination => destination.Id, opt => opt.MapFrom(src => (int?)src.Id))
                .ForMember(destination => destination.Title, opt => opt.MapFrom(src => src.Title))
                .ForMember(destination => destination.SupersetId, opt => opt.MapFrom(src => src.SupersetId));              
            CreateMap<Set, SetModel>()
                .ForMember(destination => destination.Id, opt => opt.MapFrom(src => (int)src.Id))
                .ForMember(destination => destination.Title, opt => opt.MapFrom(src => src.Title))
                .ForMember(destination => destination.SupersetId, opt => opt.MapFrom(src => src.SupersetId));
        }
    }
}
