using System.Collections.Generic;

namespace Mmu.Mls2.WebApi.Areas.Application.Dtos
{
    public class NewLearningSessionDto
    {
        public List<string> FactIds { get; set; }
        public string SessionName { get; set; }
    }
}