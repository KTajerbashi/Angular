using FluentValidation;

namespace AngularApp.Core.Application.UseCases.Aggregate
{
    public class UserInfoValidator : AbstractValidator<UserInfo>
    {
        public UserInfoValidator()
        {
            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage("First name is required")
                .Length(2, 50).WithMessage("First name must be between 2 and 50 characters");

            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage("Last name is required")
                .Length(2, 50).WithMessage("Last name must be between 2 and 50 characters");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email is required")
                .EmailAddress().WithMessage("Invalid email address")
                .MaximumLength(100);

            RuleFor(x => x.Phone)
                .NotEmpty().WithMessage("Phone number is required")
                .Matches(@"^[0-9]{10,15}$").WithMessage("Phone number must be 10-15 digits");

            RuleFor(x => x.DateBirth)
                .NotEmpty().WithMessage("Date of birth is required")
                .Must(BeValidDate).WithMessage("Invalid date format")
                .Must(BeAtLeast18YearsOld).WithMessage("You must be at least 18 years old");

            RuleFor(x => x.Gender)
                .IsInEnum().WithMessage("Invalid gender value");
        }

        private bool BeValidDate(string dateBirth)
        {
            return DateTime.TryParse(dateBirth, out _);
        }

        private bool BeAtLeast18YearsOld(string dateBirth)
        {
            if (!DateTime.TryParse(dateBirth, out DateTime birthDate))
                return false;

            var today = DateTime.Today;
            var age = today.Year - birthDate.Year;
            if (birthDate.Date > today.AddYears(-age)) age--;

            return age >= 18;
        }
    }
}