using AngularApp.Core.Application.UseCases.Security.Users.Models.DTOs;
using AngularApp.Core.Application.UseCases.Security.Users.Repository;
using AngularApp.Core.Domain.Entities.Security.User.Parameters;
using FluentValidation;

namespace AngularApp.Core.Application.UseCases.Security.Users.Handlers.Add;

public record AddResponse(UserDTO User);
public record AddCommand(
string FirstName,
string LastName,
string DisplayName,
string UserName,
string Email,
string PhoneNumber,
bool EmailConfirmed,
bool PhoneNumberConfirmed) : ICommand<AddResponse>;
public class AddValidator : AbstractValidator<AddCommand>
{
    public AddValidator()
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

public class AddHandler : CommandHandler<AddCommand, AddResponse>
{
    private readonly IUserRepository _repository;
    public AddHandler(ProviderServices provider, IUserRepository repository) : base(provider)
    {
        _repository = repository;
    }

    public override async Task<AddResponse> Handle(AddCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var mapper = Provider.Mapper.Map<AddCommand, UserCreateParameter>(request);
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

