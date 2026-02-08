using AngularApp.Core.Domain.Entities.Security.User;

namespace AngularApp.Core.Application.Aggregates.Security.Users.Models.DTOs;

public class UserDTO : BaseDTO, IMapFrom<UserEntity>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string DisplayName { get; set; }

    public bool IsDeleted { get; set; }

    public bool IsActive { get; set; }

    public bool IsOnline { get; set; }
    public void Mapping(Profile profile)
    {
        profile.CreateMap<UserEntity, UserDTO>();
    }
    //public void Mapping(Profile profile)
    //{
    //    profile.CreateMap<CreateUserCommand, User>()
    //        .ConstructUsing(cmd => new User(cmd.Email));
    //}
}
