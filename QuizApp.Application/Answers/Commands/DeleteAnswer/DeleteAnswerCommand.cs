using MediatR;

namespace QuizApp.Application.Answers.Commands.DeleteAnswer;

public class DeleteAnswerCommand : IRequest
{
    public int Id { get; set; }
}