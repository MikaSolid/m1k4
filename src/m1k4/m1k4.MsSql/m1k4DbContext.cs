using m1k4.Model;
using Microsoft.EntityFrameworkCore;

namespace m1k4.MsSql
{
    public class m1k4DbContext : DbContext
    {
        public m1k4DbContext(DbContextOptions<m1k4DbContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }

        public DbSet<Person> Person { get; set; }

        public DbSet<Party> Party { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Party>().ToTable("Party");
            modelBuilder.Entity<Person>().ToTable("Person");
            modelBuilder.Entity<User>().ToTable("User");
            // modelBuilder.Entity<User>().ToTable("User").HasKey( c => new { c.Id });

        }
    }

}
