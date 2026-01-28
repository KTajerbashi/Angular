using AngularApp.Core.Domain.Entities.Security.User;

namespace AngularApp.Core.Domain.Entities.Security.Group;

[Table("GroupUsers", Schema = "Security")]
public class GroupUserEntity : Entity<long>
{
    [ForeignKey(nameof(GroupEntity))]
    public long GroupId { get; private set; }
    public GroupEntity GroupEntity { get; private set; }

    [ForeignKey(nameof(UserEntity))]
    public long UserId { get; private set; }
    public UserEntity UserEntity { get; private set; }
}