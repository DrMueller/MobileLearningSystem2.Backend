using System.Collections.Generic;
using Mmu.Mlh.DataAccess.Areas.DataModeling.Models;

namespace Mmu.Mls2.WebApi.Areas.DataAccess.Repositories.DataModeling.Models
{
    public class LearningSessionDataModel : DataModelBase
    {
        public List<string> FactIds { get; set; }
        public string SessionName { get; set; }
    }
}