using MediatR;
using QuizApp.Core.Entities;

namespace QuizApp.Application.QuizResults.Queries.GetQuizResultsByQuiz;

public class GetQuizResultsByQuizQuery : IRequest<IEnumerable<QuizResult>>
{
    public int QuizId { get; set; }
}