using MediatR;

namespace QuizApp.Application.QuizResults.Commands.DeleteQuizResult;

public class DeleteQuizResultCommand : IRequest
{
    public int Id { get; set; }
}