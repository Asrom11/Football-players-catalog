using _66BitTestovoe.Server.Dal.Models;
using Microsoft.EntityFrameworkCore;

namespace _66BitTestovoe.Server.Dal;

public class ApplicationContextDb: DbContext
{
    public  DbSet<PlayerDal> PlayerDbSet { get; set; }
    public DbSet<TeamDal> TeamDbSet { get; set; }
    
    public ApplicationContextDb(DbContextOptions<ApplicationContextDb> options):
        base(options)
    {
    }
}