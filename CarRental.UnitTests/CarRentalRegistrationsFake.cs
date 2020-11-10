using System;
using System.Collections.Generic;
using System.Text;
using CarRental.UnitTests;
using CarRental.Models;
using System.Linq;

namespace CarRental.UnitTests
{
    class CarRentalRegistrationsFake : ICarRentalRegistrationsService
    {
        private readonly List<CarRentalRegistration> _carRentalRegistrations;

        public CarRentalRegistrationsFake()
        {
            _carRentalRegistrations = new List<CarRentalRegistration>()
            {
                new CarRentalRegistration() { Id = new Guid("ab2bd817-98cd-4cf3-a80a-53ea0cd9c200"),
                    CustomerSocSecNum = 15100, DateOfDeli = DateTime.Now, KmAtDelivery = 152860, KmAtReturn=0, 
                    DateOfReturn = DateTime.Now, IsReturned=false, Price =0     
                },
                new CarRentalRegistration() { Id = new Guid("815accac-fd5b-478a-a9d6-f171a2f6ae7f"), 
                    CustomerSocSecNum = 15100, DateOfDeli = DateTime.Now, KmAtDelivery = 152860, KmAtReturn=0,
                    DateOfReturn = DateTime.Now, IsReturned=false, Price =0
                },
                new CarRentalRegistration() { Id = new Guid("33704c4a-5b87-464c-bfb6-51971b4d18ad"), 
                    CustomerSocSecNum = 15100, DateOfDeli = DateTime.Now, KmAtDelivery = 152860, KmAtReturn=0,
                    DateOfReturn = DateTime.Now, IsReturned=false, Price =0
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

        public CarRentalRegistration GetById(Guid id)
        {
            return _carRentalRegistrations.Where(a => a.Id == id)
                .FirstOrDefault();
        }

        public void Remove(Guid id)
        {
            var existing = _carRentalRegistrations.First(a => a.Id == id);
            _carRentalRegistrations.Remove(existing);
        }

    }
}
