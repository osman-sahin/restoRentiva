using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace restoRentiva.Models
{
    public class ResultItem<T>
    {
        public List<T> Result { get; set; }
        public string ErrorMessage { get; set; }
    }
}
