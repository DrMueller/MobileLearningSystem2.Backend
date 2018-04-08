using AutoMapper;
using Mmu.Mls2.WebApi.Areas.Domain.Models;

namespace Mmu.Mls2.WebApi.Areas.DataAccess.Repositories.DataModeling.Models.Profiles
{
    public class FactDataModelProfile : Profile
    {
        public FactDataModelProfile()
        {
            CreateMap<Fact, FactDataModel>()
                .ForMember(d => d.AnswerText, c => c.MapFrom(f => f.AnswerText))
                .ForMember(d => d.CreationDate, c => c.MapFrom(f => f.CreationDate))
                .ForMember(d => d.Id, c => c.MapFrom(f => f.Id))
                .ForMember(d => d.QuestionText, c => c.MapFrom(f => f.QuestionText));
        }
    }
}