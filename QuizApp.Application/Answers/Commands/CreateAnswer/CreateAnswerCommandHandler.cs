using Ardalis.GuardClauses;
using MediatR;
using QuizApp.Application.Common;
using QuizApp.Core.Entities;

namespace QuizApp.Application.Answers.Commands.CreateAnswer;

public class CreateAnswerCommandHandler(IApplicationDbContext _context)
    : IRequestHandler<CreateAnswerCommand, Answer>
{
    public async Task<Answer> Handle(CreateAnswerCommand request, CancellationToken cancellationToken)
    {
        var question = await _context.Questions.FindAsync(request.QuestionId);

        Guard.Against.NotFound(request.QuestionId, question);
        
        var entity = new Answer
        {
            Description = request.Description,
            Score = request.Score,
            Question = question
        };
        
        _context.Answers.Add(entity);
        
        await _context.SaveChangesAsync(cancellationToken);

        return entity;
    }
}