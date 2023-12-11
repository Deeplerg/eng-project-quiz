using Ardalis.GuardClauses;
using MediatR;
using QuizApp.Application.Common;
using QuizApp.Core.Entities;

namespace QuizApp.Application.Questions.Commands.CreateQuestion;

public class CreateQuestionCommandHandler(IApplicationDbContext _context) 
    : IRequestHandler<CreateQuestionCommand, Question>
{
    public async Task<Question> Handle(CreateQuestionCommand request, CancellationToken cancellationToken)
    {
        var quiz = await _context.Quizzes.FindAsync(request.QuizId);

        Guard.Against.NotFound(request.QuizId, quiz);
        
        var entity = new Question()
        {
            Description = request.Description,
            Quiz = quiz
        };

        _context.Questions.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity;
    }
}