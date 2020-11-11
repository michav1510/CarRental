using System;
using System.ComponentModel.DataAnnotations;

namespace CarRental.Models
{
    
    public class CarRentalRegistration
    {
        [Key]
        public Guid Id { get; set; }
        public long RegistrNum { get; set; }

        public long CustomerSocSecNum { get; set; }

        [Flags]
        public enum VehicleCategory
        {
            SmallCar = 1,
            HatchBack = 2,
            Truck = 3
        }
        public VehicleCategory VehicleCat { get; set; }

        public DateTime DateOfDeli { get; set; } 

        public long KmAtDelivery { get; set; }
        
        public DateTime DateOfReturn { get; set; }

        public long KmAtReturn { get; set; }

        public double Price { get; set; }

        public bool IsReturned { get; set; }
        
        public CarRentalRegistration()
        {
            DateOfDeli = DateTime.Now;
            DateOfReturn = DateOfDeli;
            Price = 0;
            IsReturned = false;
            KmAtReturn = KmAtDelivery;
        }

        public CarRentalRegistration(CarRentalRegistration carrentalregistration)
        {
            Id = carrentalregistration.Id;
            RegistrNum = carrentalregistration.RegistrNum;
            CustomerSocSecNum = carrentalregistration.CustomerSocSecNum;
            VehicleCat = carrentalregistration.VehicleCat;
            DateOfDeli = carrentalregistration.DateOfDeli;
            KmAtDelivery = carrentalregistration.KmAtDelivery;
            DateOfReturn = carrentalregistration.DateOfReturn;
            KmAtReturn = carrentalregistration.KmAtReturn;
            Price = carrentalregistration.Price;
            IsReturned = carrentalregistration.IsReturned;
        }

        public static double baseHourRent = 20;
        public static double baseKmPrice = 2;
        public static double hatchbackCoeffOfDays = 1.3;
        public static double truckCoefOfDays = 1.5;
        public static double truckCoefOfKm = 1.5;
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
            TimeSpan difference = DateOfReturn - DateOfDeli;
            return difference.Days;
        }

        private long NumberOfKm()
        {
            return KmAtReturn - KmAtDelivery;
        }
    }
}
