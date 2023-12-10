using QuizApp.Core.Entities;

namespace QuizApp.Views;

public class AnswerDTO
{
    public int Id { get; set; }
    public string Description { get; set; }
    public int Score { get; set; }
    public int QuestionId { get; set; }

    public static explicit operator AnswerDTO(Answer answer)
    {
        return new AnswerDTO()
        {
            Id = answer.Id,
            Description = answer.Description,
            Score = answer.Score,
            QuestionId = answer.Question.Id
        };
    }
}