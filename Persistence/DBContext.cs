using Microsoft.EntityFrameworkCore;

using Domain;
namespace Persistence
{
    public class DBContext:DbContext
    {
        public DBContext(DbContextOptions Options):base(Options)
        {

        }

        public DbSet<Activity> Activities {get; set;}

    }
}