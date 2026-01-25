using AngularApp.Core.Domain.Entities.Security.User;

namespace AngularApp.Core.Domain.Entities.Security.Group;

[Table("GroupUsers", Schema = "Security")]
public class GroupUserEntity : Entity<long>
{
    [ForeignKey(nameof(GroupEntity))]
    public long GroupId { get; set; }
    public GroupEntity GroupEntity { get; set; }

    [ForeignKey(nameof(UserEntity))]
    public long UserId { get; set; }
    public UserEntity UserEntity { get; set; }
}