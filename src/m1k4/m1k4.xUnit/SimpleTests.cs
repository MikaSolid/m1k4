using m1k4.MsSql;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Xunit;
using Microsoft.Extensions.Configuration;

namespace m1k4.xUnit
{
    public class SimpleTests
    {
        [Fact]
        public void EqualIntTest()
        {
            int i = 5;
            Assert.Equal(5, i);
        }

        [Fact]
        public void TestDb()
        {
            var builder = new ConfigurationBuilder()
              .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
              .AddEnvironmentVariables();

            var Configuration = builder.Build();
            var optionsBuilder = new DbContextOptionsBuilder<m1k4DbContext>();
            var cnString = Configuration.GetConnectionString("DefaultConnection");
            optionsBuilder.UseSqlServer(cnString);
            var db = new m1k4DbContext(optionsBuilder.Options);
            var users = db.Users.First();
        }
    }
}
