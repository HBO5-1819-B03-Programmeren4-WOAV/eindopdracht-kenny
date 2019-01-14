﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using B03.EE.BlanckeK.Api.Repositories.Base;
using B03.EE.BlanckeK.Lib.DTO;
using B03.EE.BlanckeK.Lib.Models;
using Microsoft.EntityFrameworkCore;

namespace B03.EE.BlanckeK.Api.Repositories
{
    public class QuestionRepository : MappingRepository<Question>
    {
        public QuestionRepository(QuizContext context, IMapper mapper) : base(context, mapper)
        {
        }

        // returns a list of all the questions
        public async Task<List<Question>> GetAllInclusive()
        {
            return await GetAll()
                .Include(q => q.AnswerList)
                .OrderBy(a => a.SortId)
                .ToListAsync();
        }

        // returns a list of all the questions for a given quiz
        public async Task<List<Question>> GetAllQuestionsForQuiz(string id)
        {
            return await GetAll()
                .Where(a => a.QuizId == id)
                .OrderBy(a => a.SortId)
                .ToListAsync();
        }

       /* // returns a list of all questions but no to detailed
        public async Task<List<QuestionBasic>> QuestionBasic()
        {
            return await Db.Questions.ProjectTo<QuestionBasic>(Mapper.ConfigurationProvider).ToListAsync();
        }*/
    }
}
