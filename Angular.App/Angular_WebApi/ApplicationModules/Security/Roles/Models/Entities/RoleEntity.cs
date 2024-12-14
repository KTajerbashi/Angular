using Angular_WebApi.ApplicationBases.Models;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Angular_WebApi.ApplicationModules.Security.Roles.Models.Entities;

[Table("Roles", Schema = "Identity")]
public class RoleEntity : IdentityRole<long>, IBaseEntity<long>
{
    public bool IsDeleted { get; set; } = false;
    public bool IsActive { get; set; } = true;
    public string Title { get; set; }
    public RoleEntity()
    {
        IsDeleted = false;
        IsActive = true;
    }

    public RoleEntity(string name, string title)
    {
        Name = name;
        Title = title;
    }

    public void Update(string name, string title)
    {
        Name = name;
        Title = title;
    }

}
