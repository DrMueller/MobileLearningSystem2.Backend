using AutoMapper;
using Mmu.Mls2.WebApi.Areas.Domain.Models;

namespace Mmu.Mls2.WebApi.Areas.Application.Dtos.Profiles
{
    public class LearningSessionDtoProfile : Profile
    {
        public LearningSessionDtoProfile()
        {
            CreateMap<LearningSession, LearningSessionDto>()
                .ForMember(d => d.Id, c => c.MapFrom(f => f.Id))
                .ForMember(d => d.SessionName, c => c.MapFrom(f => f.SessionName));

            CreateMap<LearningSessionDto, LearningSession>()
                .ForMember(d => d.SessionName, c => c.MapFrom(f => f.SessionName));
        }
    }
}