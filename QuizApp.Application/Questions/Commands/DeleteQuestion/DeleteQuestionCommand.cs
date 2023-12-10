using MediatR;

namespace QuizApp.Application.Questions.Commands.DeleteQuestion;

public class DeleteQuestionCommand : IRequest
{
    public int Id { get; set; }
}