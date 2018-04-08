using System;
using Mmu.Mlh.DataAccess.Areas.DataModeling.Models;

namespace Mmu.Mls2.WebApi.Areas.DataAccess.Repositories.DataModeling.Models
{
    public class FactDataModel : DataModelBase
    {
        public string AnswerText { get; set; }
        public DateTime CreationDate { get; set; }
        public string QuestionText { get; set; }
    }
}