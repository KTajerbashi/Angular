using AngularApp.Core.Application.Aggregates.Security.Roles.Repository;
using AngularApp.Core.Domain.Entities.Security.Role;
using AngularApp.Infra.Data.Common;
using AngularApp.Infra.Data.DataContext;

namespace AngularApp.Infra.Data.Repositories;

public class RoleRepository : BaseRepository<RoleEntity, long>, IRoleRepository
{
    public RoleRepository(DatabaseContext context) : base(context)
    {
    }
}
