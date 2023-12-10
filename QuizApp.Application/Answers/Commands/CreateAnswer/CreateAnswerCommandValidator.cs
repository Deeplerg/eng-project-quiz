using FluentValidation;

namespace QuizApp.Application.Answers.Commands.CreateAnswer;

public class CreateAnswerCommandValidator : AbstractValidator<CreateAnswerCommand>
{
    public CreateAnswerCommandValidator()
    {
        RuleFor(m => m.Description)
            .NotEmpty();

        RuleFor(m => m.Score)
            .GreaterThanOrEqualTo(0);
    }
}