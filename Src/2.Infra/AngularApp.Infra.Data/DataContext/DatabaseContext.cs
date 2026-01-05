using AngularApp.Infra.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace AngularApp.Infra.Data.DataContext;

public class DatabaseContext : BaseDataContext
{
    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
    {
    }
}
