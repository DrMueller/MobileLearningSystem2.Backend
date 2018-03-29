using System.Collections.Generic;

namespace Mmu.Mls2.WebApi.Areas.Application.Dtos
{
    public class LearningSessionEditDto
    {
        public List<string> FactIds { get; set; }
        public string Id { get; set; }
        public string SessionName { get; set; }
    }
}