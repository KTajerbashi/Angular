using AngularApp.Core.Application.UseCases.Security.Users.Repository;

namespace AngularApp.Core.Application.UseCases.Security.Users.Handlers.Remove;
public class RemoveCommand : ICommand
{
    public Guid EntityId { get; set; }

    public RemoveCommand(Guid entityId)
    {
        EntityId = entityId;
    }
}
public class RemoveHandler : CommandHandler<RemoveCommand>
{
    private readonly IUserRepository _repository;
    public RemoveHandler(ProviderServices provider, IUserRepository repository) : base(provider)
    {
        _repository = repository;
    }

    public override async Task Handle(RemoveCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var entity = await _repository.RemoveAsync(request.EntityId, cancellationToken);
            await _repository.SaveChangesAsync(cancellationToken);
        }
        catch (Exception ex)
        {
            throw ex.ThrowAppException();
        }
    }
}

