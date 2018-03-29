using AutoMapper;
using Mmu.Mls2.WebApi.Areas.Domain.Models;

namespace Mmu.Mls2.WebApi.Areas.Application.Dtos.Profiles
{
    public class LearningSessionRunFactDtoProfile : Profile
    {
        public LearningSessionRunFactDtoProfile()
        {
            CreateMap<Fact, LearningSessionRunFactDto>()
                .ForMember(d => d.CreationDate, c => c.MapFrom(f => f.CreationDate))
                .ForMember(d => d.FactId, c => c.MapFrom(f => f.Id))
                .ForMember(d => d.AnswerText, c => c.MapFrom(f => f.AnswerText))
                .ForMember(d => d.QuestionText, c => c.MapFrom(f => f.QuestionText));
        }
    }
}