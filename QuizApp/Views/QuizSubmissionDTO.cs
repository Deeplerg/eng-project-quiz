using QuizApp.Core.Entities;

namespace QuizApp.Views;

public class QuizSubmissionDTO
{
    public IList<int> Answers { get; set; } = new List<int>();
    public DateTimeOffset SubmittionDate { get; set; }
    public int QuizId { get; set; }
    public int TotalScore { get; set; }
    public int QuizResultId { get; set; }
    
    public static explicit operator QuizSubmissionDTO(QuizSubmission qs)
    {
        int score = qs.CalculateTotalScore();
        
        return new QuizSubmissionDTO()
        {
            Answers = qs.Answers.Select(a => a.Id).ToList(),
            SubmittionDate = qs.SubmissionDate,
            QuizId = qs.ParentQuiz.Id,
            TotalScore = score,
            QuizResultId = qs.GetResult(score).Id
        };
    }
}