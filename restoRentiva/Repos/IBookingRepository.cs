using restoRentiva.Dtos;
using restoRentiva.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace restoRentiva.Repos
{
    public interface IBookingRepository
    {
        bool CreateBooking(BookingDto dto);
    }
}
