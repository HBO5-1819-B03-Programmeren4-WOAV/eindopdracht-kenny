using System.Collections.Generic;
using System.Linq;
using B03.EE.BlanckeK.DTO;
using B03.EE.BlanckeK.Models;
using Microsoft.EntityFrameworkCore;

namespace B03.EE.BlanckeK.Repositories
{
    public class UserRepository
    {
        private QuizContext _db;

        public UserRepository(QuizContext db)
        {
            _db = db;
        }

        public List<User> GetAllInclusive()
        {
            // returns a list of all users
            return _db.Users
                .Include(a => a.Quizzes)
                .ThenInclude(a => a.Questions)
                .ThenInclude(a => a.AnswerList).ToList();
        }

        public List<UserBasic> UserBasic()
        {
            return _db.Users.Select(q => new UserBasic
            {
                UserId = q.UserId,
                UserName = $"{q.FirstName} {q.LastName}"
            }).ToList();
        }

        public User GetUserById(int userId)
        {
            return GetAllInclusive().FirstOrDefault(user => user.UserId == userId);
        }
    }
}
