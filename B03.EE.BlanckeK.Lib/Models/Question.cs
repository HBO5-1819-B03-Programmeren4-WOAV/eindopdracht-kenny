using System.Collections.Generic;

namespace B03.EE.BlanckeK.Lib.Models
{
    public class Question
    {
        public int QuestionId { get; set; }
        public string QuestionText { get; set; }

        public int QuizId { get; set; }

        public ICollection<Answer> AnswerList { get; set; }
    }
}
