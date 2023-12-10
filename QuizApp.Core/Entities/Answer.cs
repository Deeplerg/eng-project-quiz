using QuizApp.Core.Common;

namespace QuizApp.Core.Entities;

public class Answer : BaseEntity<int>
{
    public string Description { get; set; } = string.Empty;
    public int Score { get; set; }
    public Question Question { get; set; }
}