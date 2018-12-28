namespace B03.EE.BlanckeK.Lib.Models
{
    public class Answer
    {
        public int AnswerId { get; set; }
        public string AnswerText { get; set; }
        public bool IsCorrectAnswer { get; set; }

        public int QuestionId { get; set; }
    }
}
