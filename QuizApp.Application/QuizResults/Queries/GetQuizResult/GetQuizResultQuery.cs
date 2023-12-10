using MediatR;
using QuizApp.Core.Entities;

namespace QuizApp.Application.QuizResults.Queries.GetQuizResult;

public class GetQuizResultQuery : IRequest<QuizResult?>
{
    public int Id { get; set; }
}