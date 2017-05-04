using System;
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
    }
}
