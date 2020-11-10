using System;
using System.Collections.Generic;

namespace CarRental.Models
{
    public interface ICarRentalRegistrationsService
    {
        IEnumerable<CarRentalRegistration> GetAllItems();
        CarRentalRegistration Add(CarRentalRegistration newItem);
        CarRentalRegistration GetById(Guid id);
        void Remove(Guid id);

    }
}