using Xunit;
using CarRental.Controllers;
using CarRental.Models;

namespace CarRental.UnitTests
{
    public class CarRentalRegistrationsControllerTest
    {
        CarRentalRegistrationsController _controller;
        ICarRentalRegistrationsService _service;
        public CarRentalRegistrationsControllerTest()
        {
            _service = new CarRentalRegistrationsFake();
            _controller = new CarRentalRegistrationsController();
        }

        [Fact]
        public void IsPrime_InputIs1_ReturnFalse()
        {
            var fortestclass = new forTestClass();
            bool result = fortestclass.IsPrime(1);

            Assert.False(result, "1 should not be prime");
        }
    }
}
