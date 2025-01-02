using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Angular.DomainLibrary.Identity;

[Table("Roles", Schema = "Identity")]
public class RoleEntity : IdentityRole<int>
{
    public string Title { get; set; }
    public RoleEntity()
    {

    }
    public RoleEntity(string name, string title)
    {
        Name = name;
        Title = title;
    }
}
