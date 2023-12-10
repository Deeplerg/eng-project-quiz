using FluentValidation;

namespace QuizApp.Application.Questions.Commands.CreateQuestion;

public class CreateQuestionCommandValidator : AbstractValidator<CreateQuestionCommand>
{
    public CreateQuestionCommandValidator()
    {
        RuleFor(m => m.Description)
            .NotEmpty();
    }
}