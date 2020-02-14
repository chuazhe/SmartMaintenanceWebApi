using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartMaintenanceWebApi.Models;


namespace SmartMaintenanceWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AircraftController : Controller
    {

        private readonly AircraftContext _context;

        public AircraftController(AircraftContext context)
        {
            this._context = context;

        }

        // GET: api/Aircraft
        /*
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
        */

        // GET: api/<controller>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Aircraft>>> GetAll()
        {
            return await _context.Aircraft.ToListAsync();
        }

        /*
        // GET: api/Aircraft/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }
        */

        // POST: api/Aircraft
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Aircraft/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
