
using AngularApp.Core.Application.Aggregates.Security.Users.Models.DTOs;
using AngularApp.Core.Application.Aggregates.Security.Users.Repository;
using AngularApp.Core.Application.Common.BaseApplication.Mediator.Command;
using AngularApp.Core.Application.Exceptions;
using AngularApp.Core.Domain.Entities.Security.User.Parameters;
using FluentValidation;

namespace AngularApp.Core.Application.Aggregates.Security.Users.Handlers.Add;

public record UserAddResponse(UserDTO User);
public record UserAddCommand(
string FirstName,
string LastName,
string DisplayName,
string UserName,
string Email,
string PhoneNumber,
bool EmailConfirmed,
bool PhoneNumberConfirmed) : ICommand<UserAddResponse>;
public class UserAddValidator : AbstractValidator<UserAddCommand>
{
    public UserAddValidator()
    {
        RuleFor(x => x.UserName)
            .NotNull()
            .NotEmpty().WithMessage("Username is null !")
            .MinimumLength(5).WithMessage("Username Can not be less than 5 charecter !!!");

        RuleFor(x => x.Email)
            .NotNull()
            .NotEmpty().WithMessage("Email is null !")
            .EmailAddress().WithMessage("Email is not valid !");

        RuleFor(x => x.PhoneNumber)
            .NotNull()
            .NotEmpty().WithMessage("PhoneNumber is null !")
            .MinimumLength(10).WithMessage("PhoneNumber Can not be less than 10 charecter !!!")
            .MaximumLength(10).WithMessage("PhoneNumber Can not be greater than 10 charecter !!!");
    }
}

public class UserAddHandler : CommandHandler<UserAddCommand, UserAddResponse>
{
    private readonly IUserRepository _repository;
    public UserAddHandler(ProviderServices provider, IUserRepository repository) : base(provider)
    {
        _repository = repository;
    }

    public override async Task<UserAddResponse> Handle(UserAddCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var mapper = Provider.Mapper.Map<UserAddCommand, UserCreateParameter>(request);
            var record = await _repository.GetAsync(1);
            UserDTO userDto = Provider.Mapper.Map<UserDTO>(record);
            return new(userDto);
        }
        catch (Exception ex)
        {
            throw ex.ThrowAppException();
        }
    }
}

