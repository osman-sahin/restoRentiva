using Microsoft.EntityFrameworkCore;
using restoRentiva.Data;
using restoRentiva.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace restoRentiva.Repos
{
    public class TableRepository : ITableRepository
    {
        private readonly RestoRentivaDbContext db;

        public TableRepository(RestoRentivaDbContext db)
        {
            this.db = db;
        }

        public ResultItem<Table> GetAll(DateTime from, DateTime to)
        {
            var getTables = db.Tables.AsNoTracking().ToList();

            foreach (var item in getTables)
            {
                item.Availability = db.Bookings.Where(b => b.TableId == item.Id).AsNoTracking().All(b => b.From >= to.AddMinutes(30) || b.To.AddMinutes(30) <= from);
            }

            ResultItem<Table> resultItem = new ResultItem<Table> { Result = getTables};
            return resultItem;
        }

        public ResultItem<Table> GetAllWithDetails()
        {
            ResultItem<Table> resultItem = new ResultItem<Table> { Result = db.Tables.Include("Bookings").AsNoTracking().ToList() };
            return resultItem;
        }

        public ResultItem<Table> GetAvailable(DateTime from, DateTime to, short capacity)
        {
            ResultItem<Table> resultItem = new ResultItem<Table>();

            TimeSpan interval = to - from;
            if (interval.TotalMinutes > 120 || interval.TotalMinutes < 30 || interval.TotalMinutes % 30 != 0)
            {
                resultItem.ErrorMessage = "Your selection must be multiplier of 30 minutes and maximum of 2 hours.";
                return resultItem;
            }

            var availableTables = db.Tables.Where(t => t.Capacity >= capacity)
                                            .Where(t => t.Bookings.All(b => b.From >= to.AddMinutes(30) || b.To.AddMinutes(30) <= from))
                                            .AsNoTracking().OrderBy(t => t.Capacity).ToList();

            if (!availableTables.Any())
            {
                resultItem.ErrorMessage = "There is no available table on your selection.";
                return resultItem;
            }

            resultItem.Result = availableTables;
            return resultItem;


        }
    }
}
