namespace QuizApp.Infrastructure.Data.Models;

public class QuestionDTO
{
    public int Id { get; set; }
    public string Description { get; set; }
    public IList<AnswerDTO> Answers { get; set; }
}