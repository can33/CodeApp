using CodeApp.Application.Dtos.Answer;

namespace CodeApp.Application.Dtos.Question
{
    public class GetAllQuestionDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string CorrectAnswer { get; set; }
        public int Score { get; set; }
        public string Description { get; set; }
        public string LanguageName { get; set; }
        public ICollection<AnswerDto> Answers { get; set; }
    }
}
