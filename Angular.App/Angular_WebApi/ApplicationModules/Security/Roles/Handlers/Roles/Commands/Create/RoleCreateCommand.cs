using Angular_WebApi.ApplicationBases.Models;
using AutoMapper;

namespace Angular_WebApi.ApplicationModules.Security.Roles.Handlers.Roles.Commands.Create;

public class RoleCreateCommand : Command<long>
{
    public string Name { get; set; }
    public string Title { get; set; }
}

