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
            // Start timing
            var startTime = DateTimeOffset.Now;
            var stopwatch = Stopwatch.StartNew();

            // Log start performance
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine($"Start PerformanceBehavior {startTime.Second}: executing...");

            // Simulate workload
            var result = new List<UserGetDTO>();
          


            for (int j = 1; j <= 5; j++)
            {
                for (int i = 1; i <= 5; i++)
                {
                    result.Add(new UserGetDTO
                    {
                        FirstName = $"Name {i}",
                        LastName = $"Family {i}",
                        Username = $"Username {i}"
                    });
                    await Task.Delay(1000);
                }
            }

            // Stop timing
            stopwatch.Stop();
            var endTime = DateTimeOffset.Now;

            // Log end performance
            Console.WriteLine($"End PerformanceBehavior {endTime.Second}: executed in {stopwatch.ElapsedMilliseconds}ms");
            Console.ResetColor();

            return result;
        }
        catch (Exception ex)
        {
            Console.ResetColor();
            Console.WriteLine($"An error occurred: {ex.Message}");
            throw;
        }
    }

}