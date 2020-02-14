using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    public class MaintenanceController : Controller
    {

        private readonly MaintenanceContext _context;

        public MaintenanceController(MaintenanceContext context)
        {
            this._context = context;
        }

        
        // GET: api/<controller>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Maintenance>>> GetAll()
        {
            return await _context.Maintenance.ToListAsync();
        }
        


        /*
        // GET: api/Maintenance
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
        */
        

        /*
    // GET: api/Maintenance/5
    [HttpGet("{id}", Name = "Get")]
    public string Get(int id)
    {
        return "value";
    }
    */


        // POST: api/<controller>
        [HttpPost("create")]
        public async Task<ActionResult<Maintenance>> CreateMaintenance([FromBody] Maintenance item)
        {
            try
            {
                item.MaintenanceId = getTopId()+1;
                _context.Maintenance.Add(item);
                await _context.SaveChangesAsync();

                /*
                return StatusCode(200);
                */
                //return http 200
                return Ok();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return StatusCode(500);
            }



            //return http 201 created
            //return CreatedAtAction(nameof(Get), new { id = item.Id, name=item.Name}, item);
        }

        [HttpGet("gettop")]
        public int getTopId()
        {
            var x = _context.Maintenance.Last().MaintenanceId;
            return x;
        }


        // POST: api/Maintenance
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Maintenance/5
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
