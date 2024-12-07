using Angular_WebApi.ApplicationBases.Handlers;
using Angular_WebApi.Middlewares.ExceptionHandler.Exceptions;
using Angular_WebApi.Utilities;

namespace Angular_WebApi.ApplicationModules.Security.Users.Handlers.Users.Commands.CreateUser;

public class UserCreateHandler : CommandHandler<UserCreateCommand, long>
{
    public UserCreateHandler(UtilitiesServices utilitiesServices) : base(utilitiesServices)
    {
    }

    public override Task<long> Handle(UserCreateCommand request, CancellationToken cancellationToken)
    {
        throw new AppException("No One Corrected ...");
    }
}