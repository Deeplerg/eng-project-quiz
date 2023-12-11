using MediatR;
using QuizApp.Core.Entities;

namespace QuizApp.Application.Questions.Commands.CreateQuestion;

public class CreateQuestionCommand : IRequest<Question>
{
    public string Description { get; set; }
    public int QuizId { get; set; }
}