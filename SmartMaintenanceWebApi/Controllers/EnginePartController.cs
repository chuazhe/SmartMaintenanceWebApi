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
    public class EnginePartController : Controller
    {

        private readonly EnginePartContext _context;

        public EnginePartController(EnginePartContext context)
        {
            this._context = context;
        }

        [HttpGet("getspecific/{id}")]
        public IEnumerable<EnginePart> GetAsync(int id)
        {
            var todoItem = _context.EnginePart.AsNoTracking().Where(s => s.EngineId == id).ToList();

            return todoItem;

        }


        /*
        // GET: api/EnginePart
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/EnginePart/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/EnginePart
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/EnginePart/5
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
