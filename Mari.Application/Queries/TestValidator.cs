using FluentValidation;

namespace Mari.Application.Queries
{
    public class TestValidator : AbstractValidator<TestQuery>
    {
        public TestValidator()
        {
            RuleFor(x => x.SomeText).Must(x => x.Length == int.MaxValue);
        }
    }
}