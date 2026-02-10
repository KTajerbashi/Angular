using AngularApp.Core.Application.UseCases.Security.Users.Repository;
using AngularApp.Core.Domain.Entities.Security.User;
using AngularApp.Infra.Data.Common;
using AngularApp.Infra.Data.DataContext;
using Microsoft.EntityFrameworkCore;

namespace AngularApp.Infra.Data.Repositories;

public class UserRepository : BaseRepository<UserEntity, long>, IUserRepository
{
    public UserRepository(DatabaseContext context) : base(context)
    {
    }
    protected override IQueryable<UserEntity> IncludeGraph(IQueryable<UserEntity> query)
       => query
           .Include(x => x.UserRoles)
           .ThenInclude(x => x.Role);
}
