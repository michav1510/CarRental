using System;
using System.Collections.Generic;
using System.Text;
using CarRental.Models;

namespace CarRental.UnitTests
{
    interface ICarRentalRegistrations
    {
        IEnumerable<CarRentalRegistration> GetAllItems();
        CarRentalRegistration Add(CarRentalRegistration newItem);
        CarRentalRegistration GetById(Guid id);
        void Remove(Guid id);

    }
}
