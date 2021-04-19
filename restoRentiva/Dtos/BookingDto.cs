using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace restoRentiva.Dtos
{
    public class BookingDto
    {
        public int TableId { get; set; }
        [Required, DataType(DataType.Time)]
        public DateTime From { get; set; }
        [Required, DataType(DataType.Time)]
        public DateTime To { get; set; }
        [Required]
        [DataType(DataType.PhoneNumber, ErrorMessage = "Invalid Phone Number")]
        [RegularExpression(@"^([0-9]{10})$", ErrorMessage = "Invalid Phone Number.")]
        public string ContactPhone { get; set; }
    }
}
