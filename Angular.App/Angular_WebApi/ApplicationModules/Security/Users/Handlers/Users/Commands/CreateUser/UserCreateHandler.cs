using Angular_WebApi.ApplicationBases.Handlers;
using Angular_WebApi.ApplicationModules.Security.Users.Interfaces;
using Angular_WebApi.Middlewares.ExceptionHandler.Exceptions;
using Angular_WebApi.Utilities;

namespace Angular_WebApi.ApplicationModules.Security.Users.Handlers.Users.Commands.CreateUser;

public class UserCreateHandler : CommandHandler<UserCreateCommand, long>
{
    private readonly IUserService _userService;
    public UserCreateHandler(UtilitiesServices utilitiesServices, IUserService userService) : base(utilitiesServices)
    {
        _userService = userService;
    }

    public override Task<long> Handle(UserCreateCommand request, CancellationToken cancellationToken)
    {
        throw new AppException("No One Corrected ...");
    }
}