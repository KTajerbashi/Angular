using Angular.ApplicationLibrary.BaseApplication.Pattern.MediatR.Queries;
using MediatR;
using System.Diagnostics;

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
            Console.Clear();
            var dataList = new List<UserGetDTO>();
            Console.Write("ILoggerFactory : ");
            Providers.LoggerFactory.CreateLogger("Start UserGetHandler");
            Console.WriteLine("============================================");
            Console.Write("ICacheAdapter : ");
            Providers.CacheAdapter.Add("Tajerbashi", "Kamrantajerbashi@gmail.com", null, null);
            var StartDate = Providers.CacheAdapter.Get<string>("Tajerbashi");
            Console.WriteLine($"==================| {StartDate} |==================");
            Console.Write("IJsonSerializer : ");
            var model = new UserGetDTO{Username = "Tajerbashi",FirstName="Kaihan",LastName="Tajer"};
            var json = Providers.JsonSerializer.Serialize(model);
            model = Providers.JsonSerializer.Deserialize<UserGetDTO>(json);
            Console.WriteLine($"==================| {json} |==================");
            Console.WriteLine("============================================");
            Console.Write("IUserInfoService : ");
            Console.WriteLine("============================================");
            await Task.Delay(1000);
            return dataList;
        }
        catch
        {

            throw;
        }
    }

}