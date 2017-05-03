using System;
using Xunit;

namespace m1k4.xUnit
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            int i = 5;
            Assert.NotEqual(5, i);
        }
    }
}
