using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Angular_WebApi.ContextDB;

public abstract class BaseDatabaseContext : IdentityDbContext
{

}

public class DatabaseContext : BaseDatabaseContext
{

}
