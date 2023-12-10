using QuizApp.Core.Entities;

namespace QuizApp.Views;

public class QuizResultDTO
{
    public string Description { get; set; } = string.Empty;
    public int FromScore { get; set; }
    public int QuizId { get; set; }
    
    public static explicit operator QuizResultDTO(QuizResult qr)
    {
        return new QuizResultDTO()
        {
            Description = qr.Description,
            FromScore = qr.FromScore,
            QuizId = qr.Quiz.Id
        };
    }
}