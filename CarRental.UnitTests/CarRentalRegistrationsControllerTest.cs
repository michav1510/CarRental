using Xunit;
using CarRental.Controllers;
using CarRental.Models;
using Moq;
using CarRental.Contracts;
using Microsoft.AspNetCore.Mvc;
using System;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Linq;

namespace CarRental.UnitTests
{
    public class CarRentalRegistrationsControllerTest
    {
        private static DbContextOptions<CarRentalContext> options;
        private static CarRentalContext context;
        //first object
        private static Guid id1= new Guid("ab2bd817-98cd-4cf3-a80a-53ea0cd9c200");
        private static long customersocsecnum1 = 151100;
        private static long registrnum1 = 150899001;
        private static DateTime dateofdeli1 = DateTime.Now;
        private static long kmatdelivery1 = 150000;
        private static CarRentalRegistration.VehicleCategory vehiclecat1 = CarRentalRegistration.VehicleCategory.SmallCar;
        private static long kmatreturn1 = 150200;
        private static DateTime dateofreturn1 = DateTime.Now;
        private static double price1 = 100;
        private static bool isreturned1 = true;
        //second object
        private static Guid id2 = new Guid("815accac-fd5b-478a-a9d6-f171a2f6ae7f");
        private static long customersocsecnum2 = 151100;
        private static long registrnum2 = 150899001;
        private static DateTime dateofdeli2 = DateTime.Now;
        private static long kmatdelivery2 = 150000;
        private static CarRentalRegistration.VehicleCategory vehiclecat2 = CarRentalRegistration.VehicleCategory.SmallCar;
        private static long kmatreturn2 = 150200;
        private static DateTime dateofreturn2 = DateTime.Now;
        private static double price2 = 100;
        private static bool isreturned2 = true;
        //third object
        private static Guid id3 = new Guid("33704c4a-5b87-464c-bfb6-51971b4d18ad");
        private static long customersocsecnum3 = 151100;
        private static long registrnum3 = 150899001;
        private static DateTime dateofdeli3 = DateTime.Now;
        private static long kmatdelivery3 = 150000;
        private static CarRentalRegistration.VehicleCategory vehiclecat3 = CarRentalRegistration.VehicleCategory.SmallCar;
        private static long kmatreturn3 = 150200;
        private static DateTime dateofreturn3 = DateTime.Now;
        private static double price3 = 100;
        private static bool isreturned3 = true;

        static CarRentalRegistrationsControllerTest()
        {
            options = new DbContextOptionsBuilder<CarRentalContext>()
            .UseInMemoryDatabase(databaseName: "TodoList")
            .Options;

            context = new CarRentalContext(options);
            context.CarRentalRegistrations.Add(new CarRentalRegistration
            {
                Id = id1,
                CustomerSocSecNum = customersocsecnum1,
                RegistrNum = registrnum1,
                DateOfDeli = dateofdeli1,
                KmAtDelivery = kmatdelivery1,
                VehicleCat = vehiclecat1,
                KmAtReturn = kmatreturn1,
                DateOfReturn = dateofreturn1,
                Price = price1,
                IsReturned = isreturned1
            });
            context.CarRentalRegistrations.Add(new CarRentalRegistration
            {
                Id = id2,
                CustomerSocSecNum = customersocsecnum2,
                RegistrNum = registrnum2,
                DateOfDeli = dateofdeli2,
                KmAtDelivery = kmatdelivery2,
                VehicleCat = vehiclecat2,
                KmAtReturn = kmatreturn2,
                DateOfReturn = dateofreturn2,
                Price = price2,
                IsReturned = isreturned2
            });

            context.CarRentalRegistrations.Add(new CarRentalRegistration
            {
                Id = id3,
                CustomerSocSecNum = customersocsecnum3,
                RegistrNum = registrnum3,
                DateOfDeli = dateofdeli3,
                KmAtDelivery = kmatdelivery3,
                VehicleCat = vehiclecat3,
                KmAtReturn = kmatreturn3,
                DateOfReturn = dateofreturn3,
                Price = price3,
                IsReturned = isreturned3
            });
            context.SaveChanges();
        }
      

        [Fact]
        public async void CheckOfGetWithId()
        {
            CarRentalRegistrationsController controller = new CarRentalRegistrationsController(context);
            var result = await controller.GetCarRentalRegistration(id1);

            Assert.Equal(result.Value.Id, id1);
            Assert.Equal(result.Value.CustomerSocSecNum, customersocsecnum1);
            Assert.Equal(result.Value.RegistrNum,registrnum1);
            Assert.Equal(result.Value.KmAtDelivery,kmatdelivery1);
            Assert.Equal(result.Value.VehicleCat,vehiclecat1);
            Assert.Equal(result.Value.KmAtReturn,kmatreturn1);
            Assert.Equal(result.Value.DateOfReturn,dateofreturn1);
            Assert.Equal(result.Value.Price,price1);
            Assert.Equal(result.Value.IsReturned,isreturned1);

        }

        [Fact]
        public async void CheckOfGetAll()
        {
            CarRentalRegistrationsController controller = new CarRentalRegistrationsController(context);
            var result = await controller.GetCarRentalRegistrations();

            var list = result.Value.ToList();
            Assert.Equal(3,list.Count);

            Assert.Equal(list[0].Id, id1);
            Assert.Equal(list[0].CustomerSocSecNum, customersocsecnum1);
            Assert.Equal(list[0].RegistrNum, registrnum1);
            Assert.Equal(list[0].KmAtDelivery, kmatdelivery1);
            Assert.Equal(list[0].VehicleCat, vehiclecat1);
            Assert.Equal(list[0].KmAtReturn, kmatreturn1);
            Assert.Equal(list[0].DateOfReturn, dateofreturn1);
            Assert.Equal(list[0].Price, price1);
            Assert.Equal(list[0].IsReturned, isreturned1);

            Assert.Equal(list[1].Id, id2);
            Assert.Equal(list[1].CustomerSocSecNum, customersocsecnum2);
            Assert.Equal(list[1].RegistrNum, registrnum2);
            Assert.Equal(list[1].KmAtDelivery, kmatdelivery2);
            Assert.Equal(list[1].VehicleCat, vehiclecat2);
            Assert.Equal(list[1].KmAtReturn, kmatreturn2);
            Assert.Equal(list[1].DateOfReturn, dateofreturn2);
            Assert.Equal(list[1].Price, price2);
            Assert.Equal(list[1].IsReturned, isreturned2);

            Assert.Equal(list[2].Id, id3);
            Assert.Equal(list[2].CustomerSocSecNum, customersocsecnum3);
            Assert.Equal(list[2].RegistrNum, registrnum3);
            Assert.Equal(list[2].KmAtDelivery, kmatdelivery3);
            Assert.Equal(list[2].VehicleCat, vehiclecat3);
            Assert.Equal(list[2].KmAtReturn, kmatreturn3);
            Assert.Equal(list[2].DateOfReturn, dateofreturn3);
            Assert.Equal(list[2].Price, price3);
            Assert.Equal(list[2].IsReturned, isreturned3);

        }

    }

}
