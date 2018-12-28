using System.Collections.Generic;

namespace B03.EE.BlanckeK.Lib.Models
{
    public class Quiz
    {
        public int QuizId { get; set; }
        public string QuizName { get; set; }

        public int UserId { get; set; }

        public ICollection<Question> Questions { get; set; }
    }
}
