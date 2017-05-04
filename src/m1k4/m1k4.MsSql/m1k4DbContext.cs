using m1k4.Model;
using Microsoft.EntityFrameworkCore;

namespace m1k4.MsSql
{
    public class m1k4DbContext : DbContext
    {
        public m1k4DbContext(DbContextOptions<m1k4DbContext> options) : base(options)
        {
        }

        public DbSet<User> Users {get;set;}
    }

}
