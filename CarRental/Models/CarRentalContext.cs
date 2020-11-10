using Microsoft.EntityFrameworkCore;

namespace CarRental.Models
{
    public class CarRentalContext: DbContext
    {
        public CarRentalContext(DbContextOptions<CarRentalContext> options)
            : base(options)
        {
        }

        public DbSet<CarRentalRegistration> CarRentalRegistrations { get; set; }
    }
}
