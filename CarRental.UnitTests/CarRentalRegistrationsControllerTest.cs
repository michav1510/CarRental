using Xunit;
using CarRental.Controllers;
using CarRental.Models;
using Moq;
using CarRental.Contracts;
using Microsoft.AspNetCore.Mvc;
using System;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace CarRental.UnitTests
{
    public class CarRentalRegistrationsControllerTest
    {
        [Fact]
        public async void IsPrime_InputIs1_ReturnFalse()
        {
            //create In Memory Database
            var options = new DbContextOptionsBuilder<CarRentalContext>()
            .UseInMemoryDatabase(databaseName: "TodoList")
            .Options;


            //// Create mocked Context by seeding Data as per Schema///

            using (var context = new CarRentalContext(options))
            {
                context.CarRentalRegistrations.Add(new CarRentalRegistration
                {
                    Id = new Guid("ab2bd817-98cd-4cf3-a80a-53ea0cd9c200"),
                    CustomerSocSecNum = 15100,
                    RegistrNum = 150899001,
                    DateOfDeli = DateTime.Now,
                    KmAtDelivery = 150000,
                    VehicleCat = CarRentalRegistration.VehicleCategory.SmallCar
                });

                context.CarRentalRegistrations.Add(new CarRentalRegistration
                {
                    Id = new Guid("815accac-fd5b-478a-a9d6-f171a2f6ae7f"),
                    CustomerSocSecNum = 15100,
                    RegistrNum = 150884304,
                    DateOfDeli = DateTime.Now,
                    KmAtDelivery = 90000,
                    VehicleCat = CarRentalRegistration.VehicleCategory.SmallCar
                });
                context.SaveChanges();
            }

            using (var context = new CarRentalContext(options))
            {
                Guid id = new Guid("ab2bd817-98cd-4cf3-a80a-53ea0cd9c200");
                CarRentalRegistrationsController controller = new CarRentalRegistrationsController(context);
                var result = await controller.GetCarRentalRegistration(id);

                //Console.WriteLine("Typeof(actualresult)= "+actualresult);
                Assert.Equal(result.Value.Id, id);


                //var actualResult = result.Value;
                //Assert.Equal("12345", ((EmployeeDb)actualResult).Id);
            }

        }
    }
}
