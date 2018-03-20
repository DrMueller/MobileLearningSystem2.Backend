using AutoMapper;
using Mmu.Mls2.WebApi.Areas.Domain.Models;

namespace Mmu.Mls2.WebApi.Areas.Application.Dtos.Profiles
{
    public class FactDtoProfile : Profile
    {
        public FactDtoProfile()
        {
            CreateMap<Fact, FactDto>()
                .ForMember(d => d.AnswerText, c => c.MapFrom(f => f.AnswerText))
                .ForMember(d => d.CreationDate, c => c.MapFrom(f => f.CreationDate))
                .ForMember(d => d.QuestionText, c => c.MapFrom(f => f.QuestionText))
                .ForMember(d => d.Id, c => c.MapFrom(f => f.Id));

            CreateMap<FactDto, Fact>()
                .ForMember(d => d.AnswerText, c => c.MapFrom(f => f.AnswerText))
                .ForMember(d => d.QuestionText, c => c.MapFrom(f => f.QuestionText));
        }
    }
}