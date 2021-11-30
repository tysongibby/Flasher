using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FlasherData.Models;
using FlasherServer.Data.Dtos;

namespace FlasherServer.Data.AutoMapperProfiles
{
    public class SuperSetProfile : Profile
    {
        public SuperSetProfile()
        {
            CreateMap<SupersetModel, Superset>()
                .ForMember(destination => destination.Id, opt => opt.MapFrom(src => (int?)src.Id))
                .ForMember(destination => destination.Title, opt => opt.MapFrom(src => src.Title));
            CreateMap<Superset, SupersetModel>()
                .ForMember(destination => destination.Id, opt => opt.MapFrom(src => (int)src.Id))
                .ForMember(destination => destination.Title, opt => opt.MapFrom(src => src.Title));
        }
    }
}
