using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

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
