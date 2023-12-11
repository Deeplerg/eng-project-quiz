using MediatR;
using QuizApp.Core.Entities;

namespace QuizApp.Application.Quizzes.Queries.GetAllQuizzes;

public class GetAllQuizzesQuery : IRequest<IEnumerable<Quiz>>
{
}