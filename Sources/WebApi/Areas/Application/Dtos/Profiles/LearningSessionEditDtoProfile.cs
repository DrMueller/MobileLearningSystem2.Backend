using AutoMapper;
using Mmu.Mls2.WebApi.Areas.Domain.Models;

namespace Mmu.Mls2.WebApi.Areas.Application.Dtos.Profiles
{
    public class LearningSessionEditDtoProfile : Profile
    {
        public LearningSessionEditDtoProfile()
        {
            CreateMap<LearningSession, LearningSessionEditDto>()
                .ForMember(d => d.Id, c => c.MapFrom(f => f.Id))
                .ForMember(d => d.SessionName, c => c.MapFrom(f => f.SessionName))
                .ForMember(d => d.FactIds, c => c.MapFrom(f => f.FactIds));

            CreateMap<LearningSessionEditDto, LearningSession>()
                .ForMember(d => d.SessionName, c => c.MapFrom(f => f.SessionName));
        }
    }
}