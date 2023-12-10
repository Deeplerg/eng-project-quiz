using Ardalis.GuardClauses;
using MediatR;
using Microsoft.EntityFrameworkCore;
using QuizApp.Application.Common;
using QuizApp.Core.Entities;

namespace QuizApp.Application.QuizSubmissions.Commands.CreateQuizSubmission;

public class CreateQuizSubmissionCommandHandler(IApplicationDbContext _context)
    : IRequestHandler<CreateQuizSubmissionCommand, QuizSubmission>
{
    public async Task<QuizSubmission> Handle(CreateQuizSubmissionCommand request, CancellationToken cancellationToken)
    {
        var quiz = await _context
            .Quizzes
            .Include(q => q.PossibleResults)
            .FirstOrDefaultAsync(q => q.Id == request.QuizId, cancellationToken);
        
        Guard.Against.NotFound(request.QuizId, quiz);
        
        var answers = await _context
            .Answers
            .Include(a => a.Question)
            .Where(answer => request.Answers.Contains(answer.Id))
            .ToListAsync(cancellationToken);
        
        var entity = new QuizSubmission()
        {
            Answers = answers,
            SubmissionDate = DateTimeOffset.UtcNow,
            ParentQuiz = quiz
        };
        
        _context.QuizSubmissions.Add(entity);
        
        await _context.SaveChangesAsync(cancellationToken);

        return entity;
    }
}