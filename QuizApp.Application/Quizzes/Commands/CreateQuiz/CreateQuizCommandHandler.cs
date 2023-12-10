using Ardalis.GuardClauses;
using MediatR;
using QuizApp.Application.Common;
using QuizApp.Core.Entities;

namespace QuizApp.Application.Quizzes.Commands.CreateQuiz;

public class CreateQuizCommandHandler(IApplicationDbContext _context)
    : IRequestHandler<CreateQuizCommand, Quiz>
{
    public async Task<Quiz> Handle(CreateQuizCommand request, CancellationToken cancellationToken)
    {
        var entity = new Quiz()
        {
            Name = request.Name
        };
        
        _context.Quizzes.Add(entity);
        
        await _context.SaveChangesAsync(cancellationToken);

        return entity;
    }
}