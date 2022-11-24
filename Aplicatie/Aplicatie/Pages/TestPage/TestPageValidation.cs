using FluentValidation;

namespace Aplicatie.Pages;

public class TestPageValidation : AbstractValidator<TestPageViewModel>
{
    public TestPageValidation()
    {
        RuleFor(x => x.UserName).Length(3,5);
        RuleFor(x => x.Password).NotNull();
    }
}