using m1k4.MsSql;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Xunit;
using Microsoft.Extensions.Configuration;
using m1k4.Model;

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

            var result = db.ExecuteReader("SELECT * FROM PERSON");

            if (result.Read())
            {
                var user = new Person
            {
                    Id = result.GetInt32(0),
                    FirstName = result.GetString(1),  
                    LastName = result.GetString(2),  
                    Comment = result.GetString(3)
            };
            }

            var command = db.Database.GetDbConnection().CreateCommand();

//            command.

            var users = db.Users.First();
        }
    }
}
