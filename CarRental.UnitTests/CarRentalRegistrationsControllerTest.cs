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

        //first object, inside the db from start

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

        //second object, inside the db from start

        private static Guid id2 = new Guid("815accac-fd5b-478a-a9d6-f171a2f6ae7f");
        private static long customersocsecnum2 = 001120;
        private static long registrnum2 = 150899001;
        private static DateTime dateofdeli2 = DateTime.Now;
        private static long kmatdelivery2 = 150000;
        private static CarRentalRegistration.VehicleCategory vehiclecat2 = CarRentalRegistration.VehicleCategory.SmallCar;
        private static long kmatreturn2 = 150200;
        private static DateTime dateofreturn2 = DateTime.Now;
        private static double price2 = 100;
        private static bool isreturned2 = true;

        //third object, inside the db from start

        private static Guid id3 = new Guid("33704c4a-5b87-464c-bfb6-51971b4d18ad");
        private static long customersocsecnum3 = 3571100;
        private static long registrnum3 = 150899001;
        private static DateTime dateofdeli3 = DateTime.Now;
        private static long kmatdelivery3 = 150000;
        private static CarRentalRegistration.VehicleCategory vehiclecat3 = CarRentalRegistration.VehicleCategory.SmallCar;
        private static long kmatreturn3 = 150200;
        private static DateTime dateofreturn3 = DateTime.Now;
        private static double price3 = 100;
        private static bool isreturned3 = true;

        //fourth object, post inside the db 

        //private static Guid id4 = new Guid("65704c4a-5b87-464c-bfb6-51971b4d18ad");
        private static long customersocsecnum4 = 151100;
        private static long registrnum4 = 150899001;
        //private static DateTime dateofdeli4 = DateTime.Now;
        private static long kmatdelivery4 = 150000;
        private static CarRentalRegistration.VehicleCategory vehiclecat4 = CarRentalRegistration.VehicleCategory.SmallCar;
        //private static long kmatreturn4 = 150200;
        //private static DateTime dateofreturn4 = DateTime.Now;
        //private static double price4 = 100;
        //private static bool isreturned4 = true;

        //fifth object, post inside the db

        private static Guid id5 = new Guid("55705c5a-5b87-565c-bfb6-51971b5d18ad");
        private static long customersocsecnum5 = 5571100;
        private static long registrnum5 = 150899001;
        private static DateTime dateofdeli5 = DateTime.Now;
        private static long kmatdelivery5 = 150000;
        private static CarRentalRegistration.VehicleCategory vehiclecat5 = CarRentalRegistration.VehicleCategory.SmallCar;
        private static long kmatreturn5 = 150000;
        private static DateTime dateofreturn5 = DateTime.Now;
        private static double price5 = 0;
        private static bool isreturned5 = false;

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

            context.CarRentalRegistrations.Add(new CarRentalRegistration
            {
                Id = id5,
                CustomerSocSecNum = customersocsecnum5,
                RegistrNum = registrnum5,
                DateOfDeli = dateofdeli5,
                KmAtDelivery = kmatdelivery5,
                VehicleCat = vehiclecat5,
                KmAtReturn = kmatreturn5,
                DateOfReturn = dateofreturn5,
                Price = price5,
                IsReturned = isreturned5
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
            Assert.Equal(4,list.Count);

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

        // Check if the default post with the fields of delivery are return correctly and if the this hold also for return fields 
        // So when you send a POST request with CustomerSocialNumber, RegistrationNumber,KilometersAtDeliveryTime, VehicleCategory
        // then the id,DateOfDelivery are initialized by its own with a "Guid Id" and the "DateTime.Now" respectively. The
        // KilometersAtReturn are initialized equals to KilometersAtReturnTime the DateOfReturn is initialized equal to the
        // DateOfDelivery. The Price is initialized to zero and the isReturned equal to false.
        [Fact]
        public async void CheckPost()
        {
            CarRentalRegistration senditem = new CarRentalRegistration
            {
                CustomerSocSecNum = customersocsecnum4,
                RegistrNum = registrnum4,
                KmAtDelivery = kmatdelivery4,
                VehicleCat = vehiclecat4,

            };
            
            CarRentalRegistrationsController controller = new CarRentalRegistrationsController(context);
            var result = await controller.PostCarRentalRegistration(senditem);
            CarRentalRegistration resultitem = (result.Result as CreatedAtActionResult).Value as CarRentalRegistration;


            Assert.NotNull(resultitem);
            Assert.Equal(customersocsecnum4, resultitem.CustomerSocSecNum);
            Assert.Equal(registrnum4, resultitem.RegistrNum);
            Assert.Equal(kmatdelivery4, resultitem.KmAtDelivery);
            Assert.Equal(vehiclecat4, resultitem.VehicleCat);
            Assert.Equal(resultitem.DateOfDeli, resultitem.DateOfReturn);
            Assert.Equal(0, resultitem.Price);
            Assert.False(resultitem.IsReturned);

        }

        //Check the PUT if it works well. We send a PUT request to an already existent CarRentalRegistration item and we 
        //check if every field of the item is Ok. In this scenario we return a Small Car 2 days after a
        [Fact]
        public async void CheckPUT()
        {
            int numberofkmafterthedelivery = 100;
            int numberofdaysafter = 2;
            CarRentalReturn carreturn = new CarRentalReturn {Id=id5, KmAtReturn = kmatreturn5+ numberofkmafterthedelivery,
                                                             DateOfReturn= dateofdeli5.AddDays(numberofdaysafter) };

            CarRentalRegistrationsController controller = new CarRentalRegistrationsController(context);
            await controller.PutCarRentalRegistration(id5, carreturn);

            var result = await controller.GetCarRentalRegistration(id5);

            Assert.Equal(id5,result.Value.Id);
            Assert.Equal(customersocsecnum5, result.Value.CustomerSocSecNum);
            Assert.Equal(registrnum5, result.Value.RegistrNum);
            Assert.Equal(kmatdelivery5, result.Value.KmAtDelivery);
            Assert.Equal(vehiclecat5, result.Value.VehicleCat);
            Assert.Equal(kmatreturn5 + numberofkmafterthedelivery, result.Value.KmAtReturn);
            Assert.Equal(dateofdeli5.AddDays(numberofdaysafter), result.Value.DateOfReturn);
            Assert.Equal(CarRentalRegistration.baseHourRent*2, result.Value.Price);
            Assert.True(result.Value.IsReturned);
        }

    }

}
