using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CarRental.Models
{
    public class CarRentalReturn
    {
        [Key]
        public long ReservNum{get ; set;}
        public long KmAtReturn{ get; set;}
        public long DateOfReturn{get; set;}


    }
}
