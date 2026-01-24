namespace AngularApp.Core.Domain.Entities.Security.Group;

[Table("Groups", Schema = "Security")]
public class GroupEntity : AggregateRoot
{
    public string Title { get; set; }
    public string Key { get; set; }

}