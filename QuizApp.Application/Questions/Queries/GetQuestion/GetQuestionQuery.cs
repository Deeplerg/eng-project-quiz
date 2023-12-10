using MediatR;
using QuizApp.Core.Entities;

namespace QuizApp.Application.Questions.Queries.GetQuestion;

public class GetQuestionQuery : IRequest<Question?>
{
    public int Id { get; set; }
}