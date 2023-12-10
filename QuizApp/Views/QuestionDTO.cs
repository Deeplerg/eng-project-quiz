using QuizApp.Core.Entities;

namespace QuizApp.Views;

public class QuestionDTO
{
    public int Id { get; set; }
    public string Description { get; set; }
    public IList<int> Answers { get; set; } = new List<int>();
    public int QuizId { get; set; }
    
    public static explicit operator QuestionDTO(Question question)
    {
        return new QuestionDTO
        {
            Id = question.Id,
            Description = question.Description,
            Answers = question.PossibleAnswers.Select(answer => answer.Id).ToList(),
            QuizId = question.Quiz.Id
        };
    }
}