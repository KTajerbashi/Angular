using Angular.ApplicationLibrary.BaseApplication.Pattern.MediatR.Queries;

namespace Angular.ApplicationLibrary.Modules.Identity.Users.Queries.Get;

public class UserGetDTO
{
    public string Username { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
}



public class UserGetQuery : Query<List<UserGetDTO>>
{

}

public class UserGetHandler : QueryHandler<UserGetQuery, List<UserGetDTO>>
{
    public UserGetHandler(ProviderServices providers) : base(providers)
    {
    }

    public override async Task<List<UserGetDTO>> Handle(UserGetQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var result = new List<UserGetDTO>();
            for (int i = 1; i <= 10; i++)
            {
                result.Add(new UserGetDTO() { FirstName = $"Name {i}", LastName = $"Family {i}", Username = $"Username {i}" });
            }
            await Task.CompletedTask;
            return result;
        }
        catch
        {

            throw;
        }
    }
}