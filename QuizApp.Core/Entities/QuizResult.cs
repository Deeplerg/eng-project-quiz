using QuizApp.Core.Common;

namespace QuizApp.Core.Entities;

public class QuizResult : BaseEntity<int>
{
    public string Description { get; set; } = string.Empty;
    public int FromScore { get; set; }
    public Quiz Quiz { get; set; }
}