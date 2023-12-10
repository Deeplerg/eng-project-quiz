using MediatR;
using QuizApp.Core.Entities;

namespace QuizApp.Application.Quizzes.Queries.GetQuiz;

public class GetQuizQuery : IRequest<Quiz?>
{
    public int Id { get; set; }
}