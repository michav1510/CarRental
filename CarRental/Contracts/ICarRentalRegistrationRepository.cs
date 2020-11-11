using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarRental.Models;

namespace CarRental.Contracts
{
    public interface ICarRentalRegistrationRepository
    {
        IEnumerable<CarRentalRegistration> GetAll();
        CarRentalRegistration GetEmployee(Guid id);
        void CreateEmployee(CarRentalRegistration carrentalregistration);
    }
}
