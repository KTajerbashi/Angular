using AngularApp.Core.Domain.Entities.Security.Enums;

namespace AngularApp.Core.Domain.Entities.Security;

[Table("Privileges", Schema = "Security")]
public class PrivilegeEntity : AggregateRoot
{
    [ForeignKey(nameof(PrivilegeEntity))]
    public long? ParentId { get; set; }
    public virtual PrivilegeEntity Children { get; set; }

    public string EntityName { get; set; }
    public string Title { get; set; }
    public PrivilegeType Type { get; set; }
    public string Command { get; set; }
    public byte Order { get; set; }
}


