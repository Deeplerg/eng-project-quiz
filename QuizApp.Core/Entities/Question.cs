using QuizApp.Core.Common;

namespace QuizApp.Core.Entities;

public class Question : BaseEntity<int>
{
    public string Description { get; set; } = string.Empty;
    public IList<Answer> PossibleAnswers { get; set; } = new List<Answer>();
    public Quiz Quiz { get; set; }
}