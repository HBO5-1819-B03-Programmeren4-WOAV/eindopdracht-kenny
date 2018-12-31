using AutoMapper;
using B03.EE.BlanckeK.Lib.DTO;
using B03.EE.BlanckeK.Lib.Models;

namespace B03.EE.BlanckeK.Api.Services
{
    public class AutoMapperConfiguration : Profile
    {
        public AutoMapperConfiguration() : this("MyProfile")
        {
        }

        public AutoMapperConfiguration(string profileName) : base(profileName)
        {
            CreateMap<AnswerBasic, Answer>();
            CreateMap<QuestionBasic, Question>();
            CreateMap<UserBasic, ApplicationUser>();
            CreateMap<QuizBasic, Quiz>();
        }
    }
}
