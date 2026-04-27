using FluentValidation;

namespace AngularApp.Core.Application.UseCases.Aggregate
{
    public class UserEducationValidator : AbstractValidator<UserEducation>
    {
        public UserEducationValidator()
        {
            RuleFor(x => x.Degree)
                .NotEmpty().WithMessage("Degree is required")
                .MaximumLength(100);

            RuleFor(x => x.Institution)
                .NotEmpty().WithMessage("Institution is required")
                .Length(3, 200).WithMessage("Institution name must be between 3 and 200 characters");

            RuleFor(x => x.GraduationYear)
                .NotEmpty().WithMessage("Graduation year is required")
                .InclusiveBetween(1950, DateTime.Now.Year + 5)
                .WithMessage("Graduation year must be between 1950 and 5 years from now");

            RuleFor(x => x.FieldOfStudy)
                .NotEmpty().WithMessage("Field of study is required")
                .Length(3, 150).WithMessage("Field of study must be between 3 and 150 characters");

            RuleFor(x => x.GPA)
                .InclusiveBetween(0, 4).When(x => x.GPA.HasValue)
                .WithMessage("GPA must be between 0 and 4");
        }
    }
}