using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using B03.EE.BlanckeK.Api.Repositories.Base;
using B03.EE.BlanckeK.Lib.DTO;
using B03.EE.BlanckeK.Lib.Models;
using Microsoft.EntityFrameworkCore;

namespace B03.EE.BlanckeK.Api.Repositories
{
    public class AnswerRepository : MappingRepository<Answer>
    {
        public AnswerRepository(QuizContext context, IMapper mapper) : base(context, mapper)
        {
        }

       // returns a list of all answers but without all the details of it
        public async Task<ICollection<AnswerBasic>> AnswerBasic()
        { 
            return await Db.Answers.ProjectTo<AnswerBasic>(Mapper.ConfigurationProvider).ToListAsync();
        }
    }
}
