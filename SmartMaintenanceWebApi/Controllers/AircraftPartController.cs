using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartMaintenanceWebApi.Models;

namespace SmartMaintenanceWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AircraftPartController : ControllerBase
    {

        private readonly AircraftPartContext _context;

        public AircraftPartController(AircraftPartContext context)
        {
            this._context = context;
        }

        // GET: api/Engine
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Engine/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }


        [HttpGet("getspecific/{id}")]
        public IEnumerable<AircraftPart> GetAsync(int id)
        {
            var todoItem = _context.AircraftPart.AsNoTracking().Where(s => s.AircraftId == id).ToList();

            return todoItem;

        }

    }
}
