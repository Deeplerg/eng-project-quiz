using MediatR;

namespace QuizApp.Application.QuizSubmissions.Commands.DeleteQuizSubmission;

public class DeleteQuizSubmissionCommand : IRequest
{
    public int Id { get; set; }
}