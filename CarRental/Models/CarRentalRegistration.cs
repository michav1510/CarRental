using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRental.Models
{
    
    public class CarRentalRegistration
    {
        [Flags]
        public enum VehicleCategory
        {
            SmallCar = 1,
            HatchBack = 2,
            Truck = 3
        }

        public long ReservNum { get; set; }

        public long RegistrNum { get; set; }

        public long CustomerSocSecNum { get; set; }

        public VehicleCategory VehicleCat { get; set; }

        public DateTime DateofDeli { get; set; }

        public long KmAtDelivery { get; set; }

        public DateTime DateofReturn { get; set; }

        public long KmAtReturn { get; set; }

        public double Price { get; set; }


        private double baseHourRent = 20;
        private double baseKmPrice = 2;
        private double hatchbackCoeffOfDays =1.3;
        private double truckCoefOfDays = 1.5;
        private double truckCoefOfKm = 1.5;
        public double CalculatePrice()
        {
            if (VehicleCat == VehicleCategory.SmallCar)
                return baseHourRent * NumberOfDays();
            else if (VehicleCat == VehicleCategory.HatchBack)
                return baseHourRent * NumberOfDays() * hatchbackCoeffOfDays + baseKmPrice * NumberOfKm();
            else
                return baseHourRent * NumberOfDays() * truckCoefOfDays + baseKmPrice * NumberOfKm() * truckCoefOfKm;
        }

        private int NumberOfDays()
        {
            TimeSpan difference = DateofReturn - DateofDeli;
            return difference.Days;
        }

        private long NumberOfKm()
        {
            return KmAtReturn - KmAtDelivery;
        }
    }
}
