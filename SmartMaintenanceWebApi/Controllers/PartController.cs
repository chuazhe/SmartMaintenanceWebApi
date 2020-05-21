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



        // GET: api/<controller>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Part>>> GetAll()
        {
            return await _context.Part.ToListAsync();
        }


        // POST: api/<controller>
        [HttpPost("create")]
        public async Task<ActionResult<Part>> CreatePart([FromBody] Part item)
        {
            try
            {
                item.PartId = getTopId() + 1;
                _context.Part.Add(item);
                await _context.SaveChangesAsync();

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
            var x = _context.Part.Last().PartId;
            return x;
        }



        // GET: api/OrderPart/5
        [HttpGet("getspecificname/{id}")]
        public string GetAsync(int id)
        {
            var todoItem = _context.Part.AsNoTracking().Where(s => s.PartId == id).ToList();

            return todoItem[0].PartName;

        }


        // GET: api/Part/5
        [HttpGet("getget")]
        public async Task<IActionResult> GetgetAsync(int id, int count)
        {
            var todoItem = await _context.Part.FindAsync(id);

            if (todoItem != null)
            {
                if (todoItem.PartCount >= count)
                {
                    return Ok(new { success = true });
                }

            }
            return BadRequest();
        }


        // POST: api/Part
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }


        // PUT: api/Order/5
        [HttpPut("add/{id}/{quantity}")]
        public async Task<IActionResult> AddAsync(int id, int quantity)
        {

            var todoItem = await _context.Part.FindAsync(id);

            if (todoItem != null)
            {

                todoItem.PartCount += quantity;
                _context.Entry(todoItem).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                return Ok();
            }
            return NotFound();

        }

        // PUT: api/Order/5
        [HttpPut("minus/{id}/{quantity}")]
        public async Task<IActionResult> MinusAsync(int id, int quantity)
        {

            var todoItem = await _context.Part.FindAsync(id);

            if (todoItem != null)
            {

                todoItem.PartCount -= quantity;
                _context.Entry(todoItem).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                return Ok();
            }
            return NotFound();

        }


        // PUT: api/Order/5
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {

            var todoItem = await _context.Part.FindAsync(id);

            if (todoItem != null)
            {

                _context.Part.Remove(todoItem);
                await _context.SaveChangesAsync();

                return Ok();
            }
            return NotFound();

        }

    }
}
