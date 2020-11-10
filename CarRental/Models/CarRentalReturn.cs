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
        public Guid Id{get ; set;}
        public long KmAtReturn{ get; set;}
        public DateTime DateOfReturn{get; set;}


        //public CarRentalReturn()
        //{
        //    DateOfReturn = DateTime.Now;
        //}

    }
}
