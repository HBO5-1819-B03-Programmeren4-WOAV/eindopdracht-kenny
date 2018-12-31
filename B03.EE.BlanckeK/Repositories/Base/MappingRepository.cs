using AutoMapper;
using B03.EE.BlanckeK.Lib.Models;

namespace B03.EE.BlanckeK.Api.Repositories.Base
{
    public class MappingRepository<T> : MainRepository<T> where T : EntityBase
    {
        protected readonly IMapper Mapper;

        public MappingRepository(QuizContext context, IMapper mapper) : base(context)
        {
            Mapper = mapper;
        }
    }
}
