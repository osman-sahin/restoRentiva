using restoRentiva.Data;
using restoRentiva.Dtos;
using restoRentiva.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace restoRentiva.Repos
{
    public class BookingRepository : IBookingRepository
    {
        private readonly RestoRentivaDbContext db;

        public BookingRepository(RestoRentivaDbContext db)
        {
            this.db = db;
        }

        public bool CreateBooking(BookingDto dto)
        {
            if (CheckEligibility(dto))
            {
                Booking booking = new Booking
                {
                    TableId = dto.TableId,
                    From = dto.From,
                    To = dto.To,
                    ContactPhone = dto.ContactPhone
                };

                db.Bookings.Add(booking);
                db.SaveChanges();
                return true;
            }
            return false;
        }

        private bool CheckEligibility(BookingDto dto)
        {
            TimeSpan interval = dto.To - dto.From;
            if (interval.TotalMinutes > 120 || interval.TotalMinutes < 30 || interval.TotalMinutes % 30 != 0)
            {
                return false;
            }

            var eligiblity = db.Bookings.Where(b => b.TableId == dto.TableId).All(b => b.From >= dto.To.AddMinutes(30) || b.To.AddMinutes(30) <= dto.From);
            return eligiblity;
        }
    }
}
