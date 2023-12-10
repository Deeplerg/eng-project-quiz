using QuizApp.Core.Common;

namespace QuizApp.Core.Entities;

public class Quiz : BaseEntity<int>
{
    public string Name { get; set; } = string.Empty;
    public IList<Question> Questions { get; set; } = new List<Question>();
    public IList<QuizResult> PossibleResults { get; set; } = new List<QuizResult>();
}