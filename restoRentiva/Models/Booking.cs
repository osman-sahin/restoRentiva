using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace restoRentiva.Models
{
    public class Booking
    {
        public int Id { get; set; }
        [ForeignKey("Table"), Required]
        public int TableId { get; set; }
        [Required, DataType(DataType.Time)]
        public DateTime From { get; set; }
        [Required, DataType(DataType.Time)]
        public DateTime To { get; set; }
        [DataType(DataType.PhoneNumber), Required]
        public string ContactPhone { get; set; }
        public Table Table { get; set; }

    }
}
