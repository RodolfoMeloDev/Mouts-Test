using FluentValidation;

namespace Ambev.DeveloperEvaluation.Domain.Validation
{
    public class BirthdayValidator : AbstractValidator<DateTime>
    {
        public BirthdayValidator()
        {
            RuleFor(birthday => birthday)
                .GreaterThan(DateTime.MinValue)
                .WithMessage($"Birthday must be greater than {DateTime.MinValue.ToString("dd/MM/yyyy")}")
                .Must(BeValidBirthday)
                .WithMessage($"Birthday must be between 16 and 120 years");
        }

        private bool BeValidBirthday(DateTime birthday)
        {
            var hoje = DateTime.Today;
            var idade = hoje.Year - birthday.Year;

            if (birthday.Date > hoje.AddYears(-idade))
                idade--;

            return idade >= 16 && idade <= 120;
        }
    }
}
