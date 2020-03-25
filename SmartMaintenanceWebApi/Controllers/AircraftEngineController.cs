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
    public class AircraftEngineController : Controller
    {

        private readonly AircraftEngineContext _context;

        public AircraftEngineController(AircraftEngineContext context)
        {
            this._context = context;

        }

        // GET: api/<controller>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AircraftEngine>>> GetAll()
        {
            return await _context.AircraftEngine.ToListAsync();
        }

        [HttpGet("getspecific/{id}")]
        public IEnumerable<AircraftEngine> GetAsync(int id)
        {
            var todoItem = _context.AircraftEngine.AsNoTracking().Where(s => s.AircraftId == id).ToList();

            return todoItem;

        }


        /*
        // GET: api/AircraftEngine
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/AircraftEngine/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/AircraftEngine
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/AircraftEngine/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
        */
    }
}
