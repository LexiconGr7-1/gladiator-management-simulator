using FluentValidation;

namespace Gladiator.Core.Validators.GladiatorValidators
{
    public class GladiatorValidator : AbstractValidator<Aggregates.GladiatorAggregate.Gladiator>
    {
        public GladiatorValidator()
        {
            RuleFor(g => g.Name)
                .NotNull().WithMessage("Gladiator name must not be null.")
                .NotEmpty().WithMessage("Gladiator name must not be empty.");

            RuleFor(g => g.Health)
                .GreaterThan(0).WithMessage("Health must be greater than 0.");

            RuleFor(g => g.Strength)
                .GreaterThan(0).WithMessage("Strength must be greater than 0.");

        }

    }
}
