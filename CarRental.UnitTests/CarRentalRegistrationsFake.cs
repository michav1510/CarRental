using System;
using System.Collections.Generic;
using System.Text;
using CarRental.UnitTests;
using CarRental.Models;

namespace CarRental.UnitTests
{
    class CarRentalRegistrationsFake : ICarRentalRegistrations
    {
        private readonly List<CarRentalRegistration> _carRentalRegistrations;

        public CarRentalRegistrationsFake()
        {
            _carRentalRegistrations = new List<CarRentalRegistration>()
            {
                new CarRentalRegistration() { Id = 1, CustomerSocSecNum = 15100, DateOfDeli = DateTime.Now,
                    KmAtDelivery = 152860, KmAtReturn=0, DateOfReturn = DateTime.Now, IsReturned=false, Price =0     
                },
                new CarRentalRegistration() { Id = 2, CustomerSocSecNum = 15100, DateOfDeli = DateTime.Now,
                    KmAtDelivery = 152860, KmAtReturn=0, DateOfReturn = DateTime.Now, IsReturned=false, Price =0
                },
                new CarRentalRegistration() { Id = 3, CustomerSocSecNum = 15100, DateOfDeli = DateTime.Now,
                    KmAtDelivery = 152860, KmAtReturn=0, DateOfReturn = DateTime.Now, IsReturned=false, Price =0
                },
            };
            
        }

        public IEnumerable<CarRentalRegistration> GetAllItems()
        {
            return _carRentalRegistrations;
        }

        public CarRentalRegistration Add(CarRentalRegistration newItem)
        {
            newItem.Id = Guid.NewGuid();
            _carRentalRegistrations.Add(newItem);
            return newItem;
        }
    }
}
