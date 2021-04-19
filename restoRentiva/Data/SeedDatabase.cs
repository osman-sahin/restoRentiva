using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace restoRentiva.Data
{
    public class SeedDatabase
    {

        public SeedDatabase(RestoRentivaDbContext dbContext)
        {
            CreateAndSeed(dbContext);
        }

        public static void CreateAndSeed(RestoRentivaDbContext dbContext)
        {
            dbContext.Database.EnsureCreated();

            if (!dbContext.Tables.Any())
            {
                Random random = new Random();
                for (int i = 1; i < 21; i++)
                {
                    dbContext.Tables.Add(new Models.Table
                    {
                        Capacity = random.Next(4, 11)
                    }); ;
                }
                dbContext.SaveChanges();


                var baseDateTime = DateTime.Today;
                foreach (var item in dbContext.Tables)
                {
                    var from = baseDateTime.AddHours(random.Next(23));
                    dbContext.Bookings.Add(new Models.Booking
                    {
                        TableId = item.Id,
                        From = from,
                        To = from.AddHours((double)random.Next(1,5)/2),
                        ContactPhone = "+901234567890"
                    });
                }


                dbContext.SaveChanges();
            }
        }
    }
}
