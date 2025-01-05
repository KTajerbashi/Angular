using Angular.ApplicationLibrary.BaseApplication.Pattern.MediatR.Queries;

namespace Angular.ApplicationLibrary.Modules.Identity.Users.Queries.GetById;
public class UserGetByIdQuery : Query<UserGetByIdDTO>
{
    public long Id { get; set; }

    public UserGetByIdQuery(long id)
    {
        Id = id;
    }
}

public class UserGetByIdHandler : QueryHandler<UserGetByIdQuery, UserGetByIdDTO>
{
    public UserGetByIdHandler(ProviderServices providers) : base(providers)
    {
    }

    public override async Task<UserGetByIdDTO> Handle(UserGetByIdQuery request, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        return new UserGetByIdDTO()
        {
            FirstName = $"FirstName {request.Id}",
            LastName = $"LastName {request.Id}",
            Username = $"Username {request.Id}"
        };
    }
}