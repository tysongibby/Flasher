using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FlasherData.Models;
using FlasherServer.Data.Dtos;

namespace FlasherServer.Data.AutoMapperProfiles
{
    public class FlashCardProfile : Profile
    {
        public FlashCardProfile()
        {
            CreateMap<FlashCardModel, FlashCard>()
                .ForMember(destination => destination.Id, opt => opt.MapFrom(src => (int?)src.Id))
                .ForMember(destination => destination.Title, opt => opt.MapFrom(src => src.Title))
                .ForMember(destination => destination.Front, opt => opt.MapFrom(src => src.Front))
                .ForMember(destination => destination.Back, opt => opt.MapFrom(src => src.Back))
                .ForMember(destination => destination.AnsweredCorrectly, opt => opt.MapFrom(src => src.AnsweredCorrectly))
                .ForMember(destination => destination.SetId, opt => opt.MapFrom(src => src.SetId))
                .ForMember(destination => destination.SupersetId, opt => opt.MapFrom(src => src.SupersetId));
            CreateMap<FlashCard, FlashCardModel>()
                .ForMember(destination => destination.Id, opt => opt.MapFrom(src => (int)src.Id))
                .ForMember(destination => destination.Title, opt => opt.MapFrom(src => src.Title))
                .ForMember(destination => destination.Front, opt => opt.MapFrom(src => src.Front))
                .ForMember(destination => destination.Back, opt => opt.MapFrom(src => src.Back))
                .ForMember(destination => destination.AnsweredCorrectly, opt => opt.MapFrom(src => src.AnsweredCorrectly))
                .ForMember(destination => destination.SetId, opt => opt.MapFrom(src => src.SetId))
                .ForMember(destination => destination.SupersetId, opt => opt.MapFrom(src => src.SupersetId)); ;
        }
    }
}
