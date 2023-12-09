using QuizApp.Core.Common;

namespace QuizApp.Core.Entities;

public class Question : BaseEntity<int>
{
    public string Description { get; set; }
    public IList<Answer> Answers { get; set; }
}