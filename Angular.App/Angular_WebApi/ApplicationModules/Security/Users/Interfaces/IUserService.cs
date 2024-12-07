﻿using Angular_WebApi.ApplicationBases.Repositories;
using Angular_WebApi.ApplicationModules.Security.Users.Models.Entities;

namespace Angular_WebApi.ApplicationModules.Security.Users.Interfaces;

public interface IUserService : IBaseRepository<UserEntity, long>
{
}
