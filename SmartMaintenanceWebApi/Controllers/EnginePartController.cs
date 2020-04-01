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

        // POST: api/<controller>
        [HttpPost("create")]
        public async Task<ActionResult<EnginePart>> CreateEnginePart([FromBody] EnginePart item)
        {
            try
            {
                _context.EnginePart.Add(item);
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

        // POST: api/<controller>
        [HttpPost("delete")]
        public async Task<ActionResult<EnginePart>> DeleteEnginePart([FromBody] EnginePart item)
        {
            try
            {
                //var todoItem = _context.EnginePart.AsNoTracking().Where(s => s.EngineId == item.EngineId && s.PartId==item.PartId);

                _context.EnginePart.Remove(item);
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
