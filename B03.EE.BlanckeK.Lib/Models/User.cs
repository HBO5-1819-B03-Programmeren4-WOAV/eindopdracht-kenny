using System;
using System.Collections.Generic;

namespace B03.EE.BlanckeK.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public DateTime DateTime { get; set; }

        public ICollection<Quiz> Quizzes { get; set; }
    }
}
