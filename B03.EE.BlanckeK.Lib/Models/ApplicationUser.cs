using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace B03.EE.BlanckeK.Lib.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public ICollection<Quiz> Quizzes { get; set; }
    }
}
