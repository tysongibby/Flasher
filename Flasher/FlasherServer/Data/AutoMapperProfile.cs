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
            CreateMap<Flashcard, FlashcardDto>()
                .ForMember(destination => destination.Id, opt => opt.MapFrom(source => (int?)source.Id))
                .ForMember(destination => destination.Name, opt => opt.MapFrom(source => source.Name))                
                .ForMember(destination => destination.Front, opt => opt.MapFrom(source => source.Front))
                .ForMember(destination => destination.Back, opt => opt.MapFrom(source => source.Back))
                .ForMember(destination => destination.CategoryId, opt => opt.MapFrom(source => source.CategoryId));
            CreateMap<FlashcardDto, Flashcard>()
                .ForMember(destination => destination.Id, opt => opt.MapFrom(source => (int)source.Id))
                .ForMember(destination => destination.Name, opt => opt.MapFrom(source => source.Name))                
                .ForMember(destination => destination.Front, opt => opt.MapFrom(source => source.Front))
                .ForMember(destination => destination.Back, opt => opt.MapFrom(source => source.Back))
                .ForMember(destination => destination.CategoryId, opt => opt.MapFrom(source => source.CategoryId));

            // Category mapping
            CreateMap<Category, CategoryDto>()
                .ForMember(destination => destination.Id, opt => opt.MapFrom(source => (int?)source.Id))
                .ForMember(destination => destination.Name, opt => opt.MapFrom(source => source.Name))
                .ForMember(destination => destination.SubjectId, opt => opt.MapFrom(source => source.SubjectId));
            CreateMap<CategoryDto, Category>()
                .ForMember(destination => destination.Id, opt => opt.MapFrom(source => (int)source.Id))
                .ForMember(destination => destination.Name, opt => opt.MapFrom(source => source.Name))
                .ForMember(destination => destination.SubjectId, opt => opt.MapFrom(source => source.SubjectId));

            // Subject mapping
            CreateMap<Subject, SubjectDto>()
                .ForMember(destination => destination.Id, opt => opt.MapFrom(source => (int?)source.Id))
                .ForMember(destination => destination.Name, opt => opt.MapFrom(source => source.Name));
            CreateMap<SubjectDto, Subject>()
                .ForMember(destination => destination.Id, opt => opt.MapFrom(source => (int)source.Id))
                .ForMember(destination => destination.Name, opt => opt.MapFrom(source => source.Name));

            // Test mapping
            CreateMap<Question, QuestionDto>()
                .ForMember(destination => destination.Id, opt => opt.MapFrom(source => source.Id))
                .ForMember(destination => destination.Number, opt => opt.MapFrom(source => source.Number))
                .ForMember(destination => destination.AnsweredCorrectly, opt => opt.MapFrom(source => source.AnsweredCorrectly))
                .ForMember(destination => destination.TestId, opt => opt.MapFrom(source => source.TestId))
                .ForMember(destination => destination.FlashcardId, opt => opt.MapFrom(source => source.FlashcardId));

            // Question mapping
            CreateMap<Test, TestDto>()
                .ForMember(destination => destination.Id, opt => opt.MapFrom(source => source.Id))
                .ForMember(destination => destination.Name, opt => opt.MapFrom(source => source.Name))
                .ForMember(destination => destination.SubjectId, opt => opt.MapFrom(source => source.SubjectId));
        }
    }
}
