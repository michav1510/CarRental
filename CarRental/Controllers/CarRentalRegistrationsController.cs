using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CarRental.Models;
using System.Drawing.Printing;

namespace CarRental.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarRentalRegistrationsController : ControllerBase
    {
        private readonly CarRentalContext _context;

        public CarRentalRegistrationsController(CarRentalContext context)
        {
            _context = context;
        }

        // GET: api/CarRentalRegistrations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CarRentalRegistration>>> GetCarRentalRegistrations()
        {
            return await _context.CarRentalRegistrations.ToListAsync();
        }

        // GET: api/CarRentalRegistrations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CarRentalRegistration>> GetCarRentalRegistration(long id)
        {
            var carRentalRegistration = await _context.CarRentalRegistrations.FindAsync(id);

            if (carRentalRegistration == null)
            {
                return NotFound();
            }

            return carRentalRegistration;
        }

        // PUT: api/CarRentalRegistrations/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCarRentalRegistration(long id, CarRentalReturn carRentalReturn)
        {
            
            if (id != carRentalReturn.ReservNum)
            {
                return BadRequest();
            }

            var carRentalRegistration = await _context.CarRentalRegistrations.FindAsync(id);
            if (carRentalRegistration == null)
            {
                return NotFound();
            }
            if (carRentalRegistration.IsReturned == true) return BadRequest(); // edo tha eprepe na iparxei ena minima isos
            if (carRentalReturn.KmAtReturn < carRentalRegistration.KmAtDelivery) return BadRequest(); // edo tha eprepe na iparxei ena minima isos
            if (DateTime.Compare(carRentalReturn.DateOfReturn, carRentalRegistration.DateOfDeli) < 0) return BadRequest(); // edo tha eprepe na iparxei ena minima isos
            carRentalRegistration.KmAtReturn = carRentalReturn.KmAtReturn;
            carRentalRegistration.DateOfReturn = carRentalReturn.DateOfReturn;
            carRentalRegistration.Price = carRentalRegistration.CalculatePrice();
            carRentalRegistration.IsReturned = true; 

            _context.Entry(carRentalRegistration).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CarRentalRegistrationExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/CarRentalRegistrations
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<CarRentalRegistration>> PostCarRentalRegistration(CarRentalRegistration carRentalRegistration)
        {
            _context.CarRentalRegistrations.Add(carRentalRegistration);
            await _context.SaveChangesAsync();

            //return CreatedAtAction("GetCarRentalRegistration", new { id = carRentalRegistration.ReservNum }, carRentalRegistration);
            return CreatedAtAction(nameof(GetCarRentalRegistration), new { id = carRentalRegistration.ReservNum }, carRentalRegistration);

        }

        // DELETE: api/CarRentalRegistrations/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CarRentalRegistration>> DeleteCarRentalRegistration(long id)
        {
            var carRentalRegistration = await _context.CarRentalRegistrations.FindAsync(id);
            if (carRentalRegistration == null)
            {
                return NotFound();
            }

            _context.CarRentalRegistrations.Remove(carRentalRegistration);
            await _context.SaveChangesAsync();

            return carRentalRegistration;
        }

        private bool CarRentalRegistrationExists(long id)
        {
            return _context.CarRentalRegistrations.Any(e => e.ReservNum == id);
        }
    }
}
