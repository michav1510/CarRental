using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarRental.Models;
using CarRental.Contracts;

namespace CarRental.Repos
{
    public class CarRentalRegistrationRepository: ICarRentalRegistrationRepository
    {
        private readonly CarRentalContext _context;

        public CarRentalRegistrationRepository(CarRentalContext context)
        {
            _context = context;
        }

        public IEnumerable<CarRentalRegistration> GetAll() => _context.CarRentalRegistrations.ToList();

        public CarRentalRegistration GetEmployee(Guid id) => _context.CarRentalRegistrations
            .SingleOrDefault(e => e.Id.Equals(id));

        public void CreateEmployee(CarRentalRegistration carrentalregistration)
        {
            carrentalregistration.Id = Guid.NewGuid();
            _context.Add(carrentalregistration);
            _context.SaveChanges();
        }
    }
}
