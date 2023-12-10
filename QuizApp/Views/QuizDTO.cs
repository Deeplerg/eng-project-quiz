using QuizApp.Core.Entities;

namespace QuizApp.Views;

public class QuizDTO
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public IList<int> Questions { get; set; } = new List<int>();
    public IList<int> PossibleResults { get; set; } = new List<int>();
    
    public static explicit operator QuizDTO(Quiz quiz)
    {
        return new QuizDTO()
        {
            Id = quiz.Id,
            Name = quiz.Name,
            Questions = quiz.Questions.Select(q => q.Id).ToList(),
            PossibleResults = quiz.PossibleResults.Select(r => r.Id).ToList()
        };
    }
}