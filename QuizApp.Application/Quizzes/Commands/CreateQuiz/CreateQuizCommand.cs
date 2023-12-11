using MediatR;
using QuizApp.Core.Entities;

namespace QuizApp.Application.Quizzes.Commands.CreateQuiz;

public class CreateQuizCommand : IRequest<Quiz>
{
    public string Name { get; set; } = string.Empty;
}