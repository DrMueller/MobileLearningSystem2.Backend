using System.Collections.Generic;
using Mmu.Mls2.WebApi.Infrastructure.DataAccess.DataModels.Abstractions;

namespace Mmu.Mls2.WebApi.Areas.DataAccess.Repositories.DataModels.Models
{
    public class LearningSessionDataModel : BaseDataModel
    {
        public List<string> FactIds { get; set; }
        public string SessionName { get; set; }
    }
}