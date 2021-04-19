using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using restoRentiva.Data;
using restoRentiva.Models;
using restoRentiva.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace restoRentiva.Controllers
{
    public class TableController : BaseController
    {
        private readonly ITableRepository tableRepository;

        public TableController(RestoRentivaDbContext db, ITableRepository tableRepository) : base(db)
        {
            this.tableRepository = tableRepository;
        }

        // GET: api/<MainController>/Details
        [HttpGet("Details")]
        public IActionResult GetAllWithBookingDetails()
        {
            return Ok(tableRepository.GetAllWithDetails().Result);
        }
        // GET: api/<MainController>/All
        [HttpGet("All")]
        public IActionResult GetAll(DateTime from, DateTime to)
        {
            var resultItem = tableRepository.GetAll(from, to);
            return Ok(resultItem.Result.Select(t => new { t.Id, t.Capacity, t.Availability }));
        }

        // GET api/<MainController>/Available
        [HttpGet("Available")]
        public IActionResult GetAvailable(DateTime from, DateTime to, short capacity)
        {
            var resultItem = tableRepository.GetAvailable(from, to, capacity);
            if (resultItem.ErrorMessage == null)
            {
                return Ok(resultItem.Result.Select(t => new { t.Id, t.Capacity, t.Availability }));
            }
            return BadRequest(resultItem);
        }

    }
}
