﻿using System.Collections.Generic;
using System.Linq;
using B03.EE.BlanckeK.Lib.DTO;
using B03.EE.BlanckeK.Lib.Models;
using Microsoft.EntityFrameworkCore;

namespace B03.EE.BlanckeK.Api.Repositories
{
    public class UserRepository
    {
        private QuizContext _db;

        public UserRepository(QuizContext db)
        {
            _db = db;
        }

        public List<ApplicationUser> GetAllInclusive()
        {
            // returns a list of all users
            return _db?.Users?.Include(a => a.Quizzes)?.ThenInclude(a => a.Questions)?.ThenInclude(a => a.AnswerList)?
                .ToList();
        }

        public List<UserBasic> UserBasic()
        {
            return _db.Users.Select(q => new UserBasic
            {
                Id = q.Id,
                UserName = q.Email

            }).ToList();
        }

        public ApplicationUser GetUserById(string id)
        {
            return GetAllInclusive().FirstOrDefault(user => user.Id == id);
        }
    }
}
