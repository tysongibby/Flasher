using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FlasherData.Models;
using FlasherServer.Data.Dtos;

namespace FlasherServer.Data
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            // Flashcard mapping
            CreateMap<FlashCardModel, Flashcard>()
                .ForMember(destination => destination.Id, opt => opt.MapFrom(src => (int?)src.Id))
                .ForMember(destination => destination.Title, opt => opt.MapFrom(src => src.Title))
                .ForMember(destination => destination.Front, opt => opt.MapFrom(src => src.Front))
                .ForMember(destination => destination.Back, opt => opt.MapFrom(src => src.Back))
                .ForMember(destination => destination.AnsweredCorrectly, opt => opt.MapFrom(src => src.AnsweredCorrectly))
                .ForMember(destination => destination.SetId, opt => opt.MapFrom(src => src.SetId))
                .ForMember(destination => destination.SupersetId, opt => opt.MapFrom(src => src.SupersetId));
            CreateMap<Flashcard, FlashCardModel>()
                .ForMember(destination => destination.Id, opt => opt.MapFrom(src => (int)src.Id))
                .ForMember(destination => destination.Title, opt => opt.MapFrom(src => src.Title))
                .ForMember(destination => destination.Front, opt => opt.MapFrom(src => src.Front))
                .ForMember(destination => destination.Back, opt => opt.MapFrom(src => src.Back))
                .ForMember(destination => destination.AnsweredCorrectly, opt => opt.MapFrom(src => src.AnsweredCorrectly))
                .ForMember(destination => destination.SetId, opt => opt.MapFrom(src => src.SetId))
                .ForMember(destination => destination.SupersetId, opt => opt.MapFrom(src => src.SupersetId)); ;

            // Set mapping
            CreateMap<SetModel, Set>()
                .ForMember(destination => destination.Id, opt => opt.MapFrom(src => (int?)src.Id))
                .ForMember(destination => destination.Title, opt => opt.MapFrom(src => src.Title))
                .ForMember(destination => destination.SupersetId, opt => opt.MapFrom(src => src.SupersetId));
            CreateMap<Set, SetModel>()
                .ForMember(destination => destination.Id, opt => opt.MapFrom(src => (int)src.Id))
                .ForMember(destination => destination.Title, opt => opt.MapFrom(src => src.Title))
                .ForMember(destination => destination.SupersetId, opt => opt.MapFrom(src => src.SupersetId));

            // Superset mapping
            CreateMap<SupersetModel, Superset>()
                .ForMember(destination => destination.Id, opt => opt.MapFrom(src => (int?)src.Id))
                .ForMember(destination => destination.Title, opt => opt.MapFrom(src => src.Title));
            CreateMap<Superset, SupersetModel>()
                .ForMember(destination => destination.Id, opt => opt.MapFrom(src => (int)src.Id))
                .ForMember(destination => destination.Title, opt => opt.MapFrom(src => src.Title));
        }
    }
}
