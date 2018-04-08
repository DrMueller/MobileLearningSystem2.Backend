using AutoMapper;
using Mmu.Mls2.WebApi.Areas.Domain.Models;

namespace Mmu.Mls2.WebApi.Areas.DataAccess.Repositories.DataModeling.Models.Profiles
{
    public class LearningSessionDataModelProfile : Profile
    {
        public LearningSessionDataModelProfile()
        {
            CreateMap<LearningSession, LearningSessionDataModel>()
                .ForMember(d => d.FactIds, c => c.MapFrom(f => f.FactIds))
                .ForMember(d => d.Id, c => c.MapFrom(f => f.Id))
                .ForMember(d => d.SessionName, c => c.MapFrom(f => f.SessionName));
        }
    }
}