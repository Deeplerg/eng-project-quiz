using FluentValidation;

namespace QuizApp.Application.QuizResults.Commands.CreateQuiz;

public class CreateQuizResultCommandValidator : AbstractValidator<CreateQuizResultCommand>
{
    public CreateQuizResultCommandValidator()
    {
        RuleFor(m => m.Description)
            .NotEmpty();

        RuleFor(m => m.FromScore)
            .GreaterThanOrEqualTo(0);
    }
}