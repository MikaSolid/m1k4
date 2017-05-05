using System;
using m1k4.Model;
using Microsoft.EntityFrameworkCore;

namespace m1k4.MsSql
{
    public class m1k4DbContext : DbContext
    {
        public m1k4DbContext()
        {
        }

        public DbSet<User> Users {get;set;}
    }

}
