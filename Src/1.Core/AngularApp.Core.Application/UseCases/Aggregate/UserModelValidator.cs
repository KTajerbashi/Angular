using FluentValidation;

namespace AngularApp.Core.Application.UseCases.Aggregate
{
    public class UserModelValidator : AbstractValidator<AddAggregateCommand>
    {
        public UserModelValidator()
        {
            RuleFor(x => x.UserInfo).SetValidator(new UserInfoValidator());
            RuleFor(x => x.UserEducation).SetValidator(new UserEducationValidator());
        }
    }
}