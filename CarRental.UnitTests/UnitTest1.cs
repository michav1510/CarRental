using System;
using Xunit;
using CarRental;

namespace CarRental.UnitTests
{
    public class UnitTest1
    {
        [Fact]
        public void IsPrime_InputIs1_ReturnFalse()
        {
            var fortestclass = new forTestClass();
            bool result = fortestclass.IsPrime(1);

            Assert.False(result, "1 should not be prime");
        }
    }
}
