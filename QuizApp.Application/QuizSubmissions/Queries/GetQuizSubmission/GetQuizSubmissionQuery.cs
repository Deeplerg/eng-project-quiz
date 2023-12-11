using MediatR;
using QuizApp.Core.Entities;

namespace QuizApp.Application.QuizSubmissions.Queries.GetQuizSubmission;

public class GetQuizSubmissionQuery : IRequest<QuizSubmission?>
{
    public int Id { get; set; }
}