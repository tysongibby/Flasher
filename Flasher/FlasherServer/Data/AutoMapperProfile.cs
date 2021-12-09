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
            CreateMap<FlashcardDm, Flashcard>()
                .ForMember(destination => destination.Id, opt => opt.MapFrom(source => (int?)source.Id))
                .ForMember(destination => destination.Title, opt => opt.MapFrom(source => source.Title))
                .ForMember(destination => destination.Front, opt => opt.MapFrom(source => source.Front))
                .ForMember(destination => destination.Back, opt => opt.MapFrom(source => source.Back))
                .ForMember(destination => destination.AnsweredCorrectly, opt => opt.MapFrom(source => source.AnsweredCorrectly))
                .ForMember(destination => destination.CategoryId, opt => opt.MapFrom(source => source.CategoryDmId));
            CreateMap<Flashcard, FlashcardDm>()
                .ForMember(destination => destination.Id, opt => opt.MapFrom(source => (int)source.Id))
                .ForMember(destination => destination.Title, opt => opt.MapFrom(source => source.Title))
                .ForMember(destination => destination.Front, opt => opt.MapFrom(source => source.Front))
                .ForMember(destination => destination.Back, opt => opt.MapFrom(source => source.Back))
                .ForMember(destination => destination.AnsweredCorrectly, opt => opt.MapFrom(source => source.AnsweredCorrectly))
                .ForMember(destination => destination.CategoryDmId, opt => opt.MapFrom(source => source.CategoryId));

            // Category mapping
            CreateMap<CategoryDm, Category>()
                .ForMember(destination => destination.Id, opt => opt.MapFrom(source => (int?)source.Id))
                .ForMember(destination => destination.Title, opt => opt.MapFrom(source => source.Title))
                .ForMember(destination => destination.SubjectId, opt => opt.MapFrom(source => source.SubjectDmId));
            CreateMap<Category, CategoryDm>()
                .ForMember(destination => destination.Id, opt => opt.MapFrom(source => (int)source.Id))
                .ForMember(destination => destination.Title, opt => opt.MapFrom(source => source.Title))
                .ForMember(destination => destination.SubjectDmId, opt => opt.MapFrom(source => source.SubjectId));

            // Subject mapping
            CreateMap<SubjectDm, Subject>()
                .ForMember(destination => destination.Id, opt => opt.MapFrom(source => (int?)source.Id))
                .ForMember(destination => destination.Title, opt => opt.MapFrom(source => source.Title));
            CreateMap<Subject, SubjectDm>()
                .ForMember(destination => destination.Id, opt => opt.MapFrom(source => (int)source.Id))
                .ForMember(destination => destination.Title, opt => opt.MapFrom(source => source.Title));
        }
    }
}
