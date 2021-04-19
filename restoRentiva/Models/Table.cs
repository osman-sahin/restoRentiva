using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace restoRentiva.Models
{
    public class Table
    {
        public int Id { get; set; }
        [Required]
        public int Capacity { get; set; }
        [NotMapped]
        public bool Availability { get; set; } = true;
        public List<Booking> Bookings { get; set; }
    }
}
