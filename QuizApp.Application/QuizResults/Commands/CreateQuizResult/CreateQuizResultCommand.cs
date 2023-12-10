using MediatR;
using QuizApp.Core.Entities;

namespace QuizApp.Application.QuizResults.Commands.CreateQuiz;

public class CreateQuizResultCommand : IRequest<QuizResult>
{
    public string Description { get; set; } = string.Empty;
    public int FromScore { get; set; }
    public int QuizId { get; set; }
}