using Angular.ApplicationLibrary.BaseApplication.Interfaces;
using Angular.DomainLibrary.Identity;

namespace Angular.ApplicationLibrary.Modules.Identity.Users.Service;

public interface IUserService : IBaseService<UserEntity, int>
{
}
