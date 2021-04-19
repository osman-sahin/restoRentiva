using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using restoRentiva.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace restoRentiva.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        public readonly RestoRentivaDbContext db;

        public BaseController(RestoRentivaDbContext db)
        {
            this.db = db;
        }
    }
}
