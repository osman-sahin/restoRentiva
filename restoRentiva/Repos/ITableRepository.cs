using restoRentiva.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace restoRentiva.Repos
{
    public interface ITableRepository
    {
        ResultItem<Table> GetAllWithDetails();
        ResultItem<Table> GetAll(DateTime from, DateTime to);
        ResultItem<Table> GetAvailable(DateTime from, DateTime to, short capacity);
    }
}
