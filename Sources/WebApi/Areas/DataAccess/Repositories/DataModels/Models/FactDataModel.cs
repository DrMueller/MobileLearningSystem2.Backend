using System;
using Mmu.Mls2.WebApi.Infrastructure.DataAccess.DataModels.Abstractions;

namespace Mmu.Mls2.WebApi.Areas.DataAccess.Repositories.DataModels.Models
{
    public class FactDataModel : BaseDataModel
    {
        public string AnswerText { get; set; }
        public DateTime CreationDate { get; set; }
        public string QuestionText { get; set; }
    }
}