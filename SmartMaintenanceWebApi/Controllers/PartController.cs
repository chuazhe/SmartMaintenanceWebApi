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
    public class PartController : Controller
    {

        private readonly PartContext _context;

        public PartController(PartContext context)
        {
            this._context = context;

        }

        /*
        // GET: api/Part
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
        */

        // GET: api/<controller>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Part>>> GetAll()
        {
            return await _context.Part.ToListAsync();
        }


        /*
        // GET: api/Part/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }
        */

        // POST: api/Part
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Part/5
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
