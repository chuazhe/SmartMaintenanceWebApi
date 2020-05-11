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


        // PUT: api/Order/5
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {

            var todoItem = await _context.Engine.FindAsync(id);

            if (todoItem != null)
            {

                _context.Engine.Remove(todoItem);
                await _context.SaveChangesAsync();

                return Ok();
            }
            return NotFound();

        }

        // POST: api/<controller>
        [HttpPost("create")]
        public async Task<ActionResult<Engine>> CreatePart([FromBody] Engine item)
        {
            try
            {
                item.EngineId = getTopId() + 1;
                //item.PartName = item.PartName;
                //item.PartCount = item.PartCount;
                _context.Engine.Add(item);
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
        }

            [HttpGet("gettop")]
        public int getTopId()
        {
            var x = _context.Engine.Last().EngineId;
            return x;
        }


        //return http 201 created
        //return CreatedAtAction(nameof(Get), new { id = item.Id, name=item.Name}, item);
    }
}

