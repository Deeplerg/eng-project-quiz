using MediatR;
using QuizApp.Core.Entities;

namespace QuizApp.Application.Questions.Queries.GetQuizQuestions;

public class GetQuizQuestionsQuery : IRequest<IEnumerable<Question>>
{
    public int QuizId { get; set; }
}