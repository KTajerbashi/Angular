
using AngularApp.Core.Application.Aggregates.Security.Users.Repository;
using AngularApp.Core.Domain.Entities.Security.User;

namespace AngularApp.Core.Application.Aggregates.Security.Users.Handlers.ReadAll;

public class ReadAllQueryModel : BaseDTO<UserEntity>
{
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string UserName { get; set; }
    public required string Email { get; set; }
    public required string PhoneNumber { get; set; }
    public required string DisplayName { get; set; }
    public bool IsDeleted { get; set; }
    public bool IsActive { get; set; }
    public bool IsOnline { get; set; }

    public override void Mapping(Profile profile)
    {
        profile.CreateMap<UserEntity, ReadAllQueryModel>().ReverseMap();
    }
}
public class ReadAllQuery : IQuery<List<ReadAllQueryModel>>
{
}
public class ReadAllHandler : QueryHandler<ReadAllQuery, List<ReadAllQueryModel>>
{
    readonly IUserRepository repository;
    public ReadAllHandler(ProviderServices provider, IUserRepository repository) : base(provider)
    {
        this.repository = repository;
    }

    public override async Task<List<ReadAllQueryModel>> Handle(ReadAllQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var entities = await repository.GetAsync(cancellationToken);
            return Provider.Mapper.MapList<UserEntity, ReadAllQueryModel>(entities).ToList();
        }
        catch (Exception ex)
        {
            throw ex.ThrowAppException();
        }
    }
}