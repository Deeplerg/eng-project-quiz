using QuizApp.Core.Common;

namespace QuizApp.Core.Entities;

public class Answer : BaseEntity<int>
{
    public string Description { get; set; }
    public int Score { get; set; }
}