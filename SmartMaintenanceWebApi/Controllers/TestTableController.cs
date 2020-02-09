using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartMaintenanceWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartMaintenanceWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    //[Authorize] JWT
    public class TestTableController : Controller
    {

        private readonly TestTableContext _context;

        public TestTableController(TestTableContext context)
        {
            this._context = context;

        }

        // GET: api/<controller>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TestTable>>> GetAll()
        {
            return await _context.TestTable.ToListAsync();
        }


        // GET: api/<controller>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TestTable>> Get(int id)
        {
            var todoItem = await _context.TestTable.FindAsync(id);

            if (todoItem == null)
            {
                return NotFound();
            }

            return todoItem;
        }

        // POST: api/<controller>
        [HttpPost]
        [EnableCors]
        public async Task<ActionResult<TestTable>> PostTestTable([FromBody] TestTable item)
        {
            try
            {
                _context.TestTable.Add(item);
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


        // PUT: api/<controller>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTodoItem(int id, [FromBody] TestTable item)
        {
            if (id != item.Id)
            {
                return BadRequest();
            }

            _context.Entry(item).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }


        // DELETE: api/<controller>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTodoItem(int id)
        {
            var todoItem = await _context.TestTable.FindAsync(id);

            if (todoItem == null)
            {
                return NotFound();
            }

            _context.TestTable.Remove(todoItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
