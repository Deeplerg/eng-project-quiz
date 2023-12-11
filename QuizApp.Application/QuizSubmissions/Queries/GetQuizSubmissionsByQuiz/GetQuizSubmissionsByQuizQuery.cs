using MediatR;
using QuizApp.Core.Entities;

namespace QuizApp.Application.QuizSubmissions.Queries.GetQuizSubmissionsByQuiz;

public class GetQuizSubmissionsByQuizQuery : IRequest<IEnumerable<QuizSubmission>>
{
    public int QuizId { get; set; }
}