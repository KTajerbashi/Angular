using AngularApp.Core.Application.UseCases.Security.Users.Repository;
using AngularApp.Core.Domain.Entities.Security.User;

namespace AngularApp.Core.Application.UseCases.Security.Users.Handlers.ReadById;

public class ReadByIdQueryModel : BaseDTO<UserEntity>
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
        profile.CreateMap<UserEntity, ReadByIdQueryModel>().ReverseMap();
    }
}

public class ReadByIdQuery : IQuery<ReadByIdQueryModel>
{
    public Guid EntityId { get; set; }

    public ReadByIdQuery(Guid entityId)
    {
        EntityId = entityId;
    }
}
public class ReadByIdHandler : QueryHandler<ReadByIdQuery, ReadByIdQueryModel>
{
    readonly IUserRepository repository;
    public ReadByIdHandler(ProviderServices provider, IUserRepository repository) : base(provider)
    {
        this.repository = repository;
    }

    public override async Task<ReadByIdQueryModel> Handle(ReadByIdQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var entities = await repository.GetAsync(request.EntityId, cancellationToken);
            return Provider.Mapper.Map<UserEntity, ReadByIdQueryModel>(entities);
        }
        catch (Exception ex)
        {
            throw ex.ThrowAppException();
        }
    }
}
