using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using B03.EE.BlanckeK.Api.Repositories.Base;
using B03.EE.BlanckeK.Lib.DTO;
using B03.EE.BlanckeK.Lib.Models;
using Microsoft.EntityFrameworkCore;

namespace B03.EE.BlanckeK.Api.Repositories
{
    public class QuizRepository : MappingRepository<Quiz>
    {

        public QuizRepository(QuizContext context, IMapper mapper) : base(context, mapper)
        {
        }

        // returns a list of all the quizzes
        public async Task<List<Quiz>> GetAllInclusive()
        {
            return await GetAll()
                .Include(q => q.Questions)
                .ThenInclude(a => a.AnswerList)
                .ToListAsync();
        }

        public async Task<Quiz> GetAllInclusiveById(string id)
        {
            return await GetAll()
                .Include(q => q.Questions)
                .ThenInclude(a => a.AnswerList)
                .FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<List<QuizBasic>> GetQuizBasics()
        {
            return await Db.Quizzes.ProjectTo<QuizBasic>(Mapper.ConfigurationProvider).ToListAsync();
        }
    }
}
