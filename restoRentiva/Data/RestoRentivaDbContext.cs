using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using restoRentiva.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace restoRentiva.Data
{
    public class RestoRentivaDbContext : DbContext
    {
        public RestoRentivaDbContext(DbContextOptions<RestoRentivaDbContext> options)
            : base(options)
        {
        }


        public DbSet<Table> Tables { get; set; }
        public DbSet<Booking> Bookings { get; set; }

    }
}
