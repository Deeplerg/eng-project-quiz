using MediatR;
using QuizApp.Core.Entities;

namespace QuizApp.Application.Answers.Commands.CreateAnswer;

public class CreateAnswerCommand : IRequest<Answer>
{
    public string Description { get; set; }
    public int Score { get; set; }
    public int QuestionId { get; set; }
}