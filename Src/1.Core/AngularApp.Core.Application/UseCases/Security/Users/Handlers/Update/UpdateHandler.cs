using AngularApp.Core.Application.UseCases.Security.Users.Repository;
using AngularApp.Core.Domain.Entities.Security.User;
using AngularApp.Core.Domain.Entities.Security.User.Parameters;

namespace AngularApp.Core.Application.UseCases.Security.Users.Handlers.Update;

public class UpdateCommand : ICommand
{
    public Guid EntityId { get; set; }

    public UpdateCommand(Guid entityId)
    {
        EntityId = entityId;
    }
}
public class UpdateHandler : CommandHandler<UpdateCommand>
{
    private readonly IUserRepository _repository;
    public UpdateHandler(ProviderServices provider, IUserRepository repository) : base(provider)
    {
        _repository = repository;
    }

    public override async Task Handle(UpdateCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var entity = await _repository.GetAsync(request.EntityId, cancellationToken);
            var parameter = Provider.Mapper.Map<UserEntity,UserUpdateParameter>(entity);
            entity.Update(parameter);
            await _repository.SaveChangesAsync(cancellationToken);
        }
        catch (Exception ex)
        {
            throw ex.ThrowAppException();
        }
    }
}



