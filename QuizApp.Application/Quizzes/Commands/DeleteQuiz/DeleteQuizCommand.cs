using MediatR;

namespace QuizApp.Application.Quizzes.Commands.DeleteQuiz;

public class DeleteQuizCommand : IRequest
{
    public int Id { get; set; }
}