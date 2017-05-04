using m1k4.MsSql;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Xunit;

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
            var optionsBuilder = new DbContextOptionsBuilder<m1k4DbContext>();
            optionsBuilder.UseSqlServer("Server=192.168.1.5;Database=m1k4;user=m1k4;password=m1k4");
            var db = new m1k4DbContext(optionsBuilder.Options);
            var users = db.Users.First();
        }
    }
}
