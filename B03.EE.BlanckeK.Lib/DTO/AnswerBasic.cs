using B03.EE.BlanckeK.Lib.Models;

namespace B03.EE.BlanckeK.Lib.DTO
{
    public class AnswerBasic : EntityBase
    {
        public string AnswerText { get; set; }
        public bool IsCorrectAnswer { get; set; }
    }
}
