using System;

namespace Mmu.Mls2.WebApi.Areas.Application.Dtos
{
    public class LearningSessionRunFactDto
    {
        public string AnswerText { get; set; }
        public DateTime CreationDate { get; set; }
        public string FactId { get; set; }
        public string QuestionText { get; set; }
    }
}