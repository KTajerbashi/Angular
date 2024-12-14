﻿using Angular_WebApi.ApplicationModules.Security.Users.Handlers.Users.Commands.CreateUser;
using Angular_WebApi.ApplicationModules.Security.Users.Handlers.Users.Queries.GetAll;
using Angular_WebApi.ApplicationModules.Security.Users.Models.DTOs;
using Angular_WebApi.ContextDB;
using Angular_WebApi.Controllers.BaseControllers;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Angular_WebApi.ApplicationModules.Security.Users.Contollers;

public class UserController : AuthController
{
    public UserController(IMediator mediator) : base(mediator)
    {
    }


    [HttpPost]
    public async Task<IActionResult> Create(UserCreateCommand model)
        => await base.Create<UserCreateCommand, long>(model);
    
    
    [HttpGet]
    public async Task<IActionResult> ReadAll()
        => await QueryList<UserGetAllQuery, UserGetAllView>(new UserGetAllQuery());

    [HttpGet("{id}")]
    public async Task<IActionResult> Read()
    {
        return Ok(true);
    }


    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(long id)
    {
        return Ok(true);
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(long id, UserDTO model)
    {
        return Ok(true);
    }
    
}
