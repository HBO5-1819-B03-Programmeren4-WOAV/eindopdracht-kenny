using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace B03.EE.BlanckeK.Lib.Models
{
    public class Quiz : EntityBase
    {
        public string QuizName { get; set; }

        [ForeignKey("ApplicationUserId")]
        public string ApplicationUserId { get; set; }

        public ICollection<Question> Questions { get; set; }
    }
}
