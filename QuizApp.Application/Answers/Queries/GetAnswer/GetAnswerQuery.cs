using MediatR;
using QuizApp.Core.Entities;

namespace QuizApp.Application.Answers.Queries.GetAnswer;

public class GetAnswerQuery : IRequest<Answer>
{
    public int Id { get; set; }
}