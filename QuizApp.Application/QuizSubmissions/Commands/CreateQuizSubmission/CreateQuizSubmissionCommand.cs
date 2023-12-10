using MediatR;
using QuizApp.Core.Entities;

namespace QuizApp.Application.QuizSubmissions.Commands.CreateQuizSubmission;

public class CreateQuizSubmissionCommand : IRequest<QuizSubmission>
{
    public IList<int> Answers { get; set; } = new List<int>();
    public int QuizId { get; set; }
}