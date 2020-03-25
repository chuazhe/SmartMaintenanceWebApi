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
    public class EngineController : Controller
    {
        private readonly EngineContext _context;

        public EngineController(EngineContext context)
        {
            this._context = context;
        }


        /*
        // GET: api/Engine
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
        */


        // GET: api/<controller>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Engine>>> GetAll()
        {
            return await _context.Engine.ToListAsync();
        }


        // GET: api/OrderPart/5
        [HttpGet("getspecificname/{id}")]
        public string GetAsync(int id)
        {
            var todoItem = _context.Engine.AsNoTracking().Where(s => s.EngineId == id).ToList();

            return todoItem[0].EngineName;

        }
        /*
        // GET: api/Engine/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        /*

        // POST: api/Engine
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Engine/5
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
