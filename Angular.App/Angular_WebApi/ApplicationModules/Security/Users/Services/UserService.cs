﻿using Angular_WebApi.ApplicationBases.Services;
using Angular_WebApi.ApplicationModules.Security.Users.Interfaces;
using Angular_WebApi.ApplicationModules.Security.Users.Models.Entity;

namespace Angular_WebApi.ApplicationModules.Security.Users.Services;

public class UserService : BaseRepository<UserEntity, long>, IUserService
{

}