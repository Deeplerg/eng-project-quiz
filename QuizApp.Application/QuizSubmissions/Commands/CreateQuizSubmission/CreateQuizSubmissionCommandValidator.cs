using FluentValidation;

namespace QuizApp.Application.QuizSubmissions.Commands.CreateQuizSubmission;

public class CreateQuizSubmissionCommandValidator : AbstractValidator<CreateQuizSubmissionCommand>
{
    public CreateQuizSubmissionCommandValidator()
    {
        RuleFor(m => m.Answers)
            .NotEmpty();
    }
}