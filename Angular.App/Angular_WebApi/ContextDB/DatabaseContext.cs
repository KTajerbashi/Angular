using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Angular_WebApi.ContextDB;

public abstract class BaseDatabaseContext : IdentityDbContext
{
    protected BaseDatabaseContext(DbContextOptions options) : base(options)
    {
    }
}

public class DatabaseContext : BaseDatabaseContext
{
    public DatabaseContext(DbContextOptions<DatabaseContext> options)
       : base(options) // Pass the options to the base DbContext constructor
    {
    }
}
