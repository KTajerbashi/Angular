using Angular_WebApi.ApplicationBases.Handlers;
using Angular_WebApi.ApplicationModules.Security.Roles.Interfaces;
using Angular_WebApi.ApplicationModules.Security.Roles.Models.Entities;
using Angular_WebApi.ApplicationModules.Security.Users.Interfaces;
using Angular_WebApi.ApplicationModules.Security.Users.Models.Entities;
using Angular_WebApi.Exceptions;
using Angular_WebApi.Utilities;
using Angular_WebApi.Utilities.Extensions;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace Angular_WebApi.ApplicationModules.Security.Users.Handlers.Users.Commands.CreateUser;

public class UserCreateHandler : CommandHandler<UserCreateCommand, long>
{
    private readonly IUserService _userService;
    private readonly IAuthorizationService _authorizationService;
    private readonly IRoleService _roleService;
    private readonly UserManager<UserEntity> _userManager;
    private readonly RoleManager<RoleEntity> _roleManager;

    public UserCreateHandler(
        UtilitiesServices utilitiesServices, 
        IUserService userService, 
        IAuthorizationService authorizationService, 
        IRoleService roleService, 
        UserManager<UserEntity> userManager, 
        RoleManager<RoleEntity> roleManager) 
        : base(utilitiesServices)
    {
        _userService = userService;
        _authorizationService = authorizationService;
        _roleService = roleService;
        _userManager = userManager;
        _roleManager = roleManager;
    }

    public override async Task<long> Handle(UserCreateCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var data = UtilitiesServices.MapperFacade.Map<UserCreateCommand,UserEntity>(request);
            var result = await _userManager.CreateAsync(data,request.Password);

            if (request.RoleId.HasValue)
            {
                var roleEntity = await _roleService.GetAsync(request.RoleId.Value,cancellationToken);
                await _userManager.AddToRoleAsync(data,roleEntity.Name);
            }


            if (result.Succeeded)
                return data.Id;
            throw new IdentityLogicException(result.GetIdentityErrors());
        }
        catch
        {

            throw;
        }
    }
}


public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<UserEntity, UserCreateCommand>().ReverseMap();
    }
}
