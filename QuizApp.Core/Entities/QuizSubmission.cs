using QuizApp.Core.Common;
using QuizApp.Core.Exceptions;

namespace QuizApp.Core.Entities;

public class QuizSubmission : BaseEntity<int>
{
    public IList<Answer> Answers { get; set; } = new List<Answer>();
    public DateTimeOffset SubmissionDate { get; set; }
    public Quiz ParentQuiz { get; set; }
    
    public int CalculateTotalScore()
    {
        return Answers.Sum(answer => answer.Score);
    }

    public QuizResult GetResult(int totalScore)
    {
        var orderedPossibleResults = ParentQuiz.PossibleResults
            .OrderByDescending(result => result.FromScore);

        foreach (var result in orderedPossibleResults)
        {
            if (totalScore >= result.FromScore)
                return result;
        }

        throw new NoQuizResultException(ParentQuiz.Name, totalScore);
    }
}