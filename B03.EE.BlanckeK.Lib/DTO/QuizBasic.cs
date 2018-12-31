using B03.EE.BlanckeK.Lib.Models;

namespace B03.EE.BlanckeK.Lib.DTO
{
    public class QuizBasic : EntityBase
    {
        public string QuizName { get; set; }
        public string ApplicationUserId { get; set; }
    }
}
