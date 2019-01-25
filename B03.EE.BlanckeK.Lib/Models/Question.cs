using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace B03.EE.BlanckeK.Lib.Models
{
    public class Question : EntityBase
    {
        public string QuestionText { get; set; }

        public string QuizId { get; set; }

        public ICollection<Answer> AnswerList { get; set; }
    }
}
