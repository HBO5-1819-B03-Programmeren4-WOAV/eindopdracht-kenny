using System.ComponentModel.DataAnnotations.Schema;

namespace B03.EE.BlanckeK.Lib.Models
{
    public class Answer : EntityBase
    {
        public string AnswerText { get; set; }
        public bool IsCorrectAnswer { get; set; }

        public string QuestionId { get; set; }
    }
}
