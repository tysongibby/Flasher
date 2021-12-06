using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FlasherData.DataModels;
using FlasherServer.Data.Dtos;

namespace FlasherServer.Data
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            // Flashcard mapping
            CreateMap<FlashCardDm, Flashcard>()
                .ForMember(destination => destination.Id, opt => opt.MapFrom(src => (int?)src.Id))
                .ForMember(destination => destination.Title, opt => opt.MapFrom(src => src.Title))
                .ForMember(destination => destination.Front, opt => opt.MapFrom(src => src.Front))
                .ForMember(destination => destination.Back, opt => opt.MapFrom(src => src.Back))
                .ForMember(destination => destination.AnsweredCorrectly, opt => opt.MapFrom(src => src.AnsweredCorrectly))
                .ForMember(destination => destination.CategoryId, opt => opt.MapFrom(src => src.CategoryDmId))
                .ForMember(destination => destination.SubjectId, opt => opt.MapFrom(src => src.SubjectDmId));
            CreateMap<Flashcard, FlashCardDm>()
                .ForMember(destination => destination.Id, opt => opt.MapFrom(src => (int)src.Id))
                .ForMember(destination => destination.Title, opt => opt.MapFrom(src => src.Title))
                .ForMember(destination => destination.Front, opt => opt.MapFrom(src => src.Front))
                .ForMember(destination => destination.Back, opt => opt.MapFrom(src => src.Back))
                .ForMember(destination => destination.AnsweredCorrectly, opt => opt.MapFrom(src => src.AnsweredCorrectly))
                .ForMember(destination => destination.CategoryDmId, opt => opt.MapFrom(src => src.CategoryId))
                .ForMember(destination => destination.SubjectDmId, opt => opt.MapFrom(src => src.SubjectId)); ;

            // Category mapping
            CreateMap<CategoryDm, Category>()
                .ForMember(destination => destination.Id, opt => opt.MapFrom(src => (int?)src.Id))
                .ForMember(destination => destination.Title, opt => opt.MapFrom(src => src.Title))
                .ForMember(destination => destination.SubjectId, opt => opt.MapFrom(src => src.SubjectDmId));
            CreateMap<Category, CategoryDm>()
                .ForMember(destination => destination.Id, opt => opt.MapFrom(src => (int)src.Id))
                .ForMember(destination => destination.Title, opt => opt.MapFrom(src => src.Title))
                .ForMember(destination => destination.SubjectDmId, opt => opt.MapFrom(src => src.SubjectId));

            // Subject mapping
            CreateMap<SubjectDm, Subject>()
                .ForMember(destination => destination.Id, opt => opt.MapFrom(src => (int?)src.Id))
                .ForMember(destination => destination.Title, opt => opt.MapFrom(src => src.Title));
            CreateMap<Subject, SubjectDm>()
                .ForMember(destination => destination.Id, opt => opt.MapFrom(src => (int)src.Id))
                .ForMember(destination => destination.Title, opt => opt.MapFrom(src => src.Title));
        }
    }
}
