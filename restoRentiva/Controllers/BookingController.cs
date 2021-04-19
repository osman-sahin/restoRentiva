using Microsoft.AspNetCore.Mvc;
using restoRentiva.Data;
using restoRentiva.Dtos;
using restoRentiva.Models;
using restoRentiva.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace restoRentiva.Controllers
{
    public class BookingController : BaseController
    {
        private readonly IBookingRepository bookingRepository;

        public BookingController(RestoRentivaDbContext db, IBookingRepository bookingRepository) : base(db)
        {
            this.bookingRepository = bookingRepository;
        }

        // POST api/<BookingController>
        [HttpPost]
        public IActionResult Post([FromBody] BookingDto dto)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (bookingRepository.CreateBooking(dto))
                    {
                        return Ok(dto);
                    };
                    return BadRequest("The table that you selected is not available anymore. Please try another one.");
                }
                catch (Exception)
                {
                    return StatusCode(503);
                }
            }
            return BadRequest("Your selection is invalid.");

            #region MyRegion
            //if (ModelState.IsValid)
            //{
            //    if (CheckEligibility(dto))
            //    {
            //        Booking booking = new Booking
            //        {
            //            TableId = dto.TableId,
            //            From = dto.From,
            //            To = dto.To,
            //            ContactPhone = dto.ContactPhone
            //        };

            //        db.Bookings.Add(booking);
            //        db.SaveChanges();
            //        return Ok(dto);
            //    }
            //    return BadRequest("Table is already booked by someone else.");
            //}
            //return BadRequest("Your selection is invalid."); 
            #endregion
        }
    }
}
