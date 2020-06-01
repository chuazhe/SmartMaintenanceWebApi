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
    public class OrderPartController : ControllerBase
    {

        private readonly OrderPartContext _context;


        public OrderPartController(OrderPartContext context)
        {
            this._context = context;
        }

        // GET: api/OrderPart/5
        [HttpGet("getspecific/{id}")]
        public IEnumerable<OrderPart> GetAsync(int id)
        {
            var todoItem = _context.OrderPart.AsNoTracking().Where(s => s.OrderId == id).ToList();

            return todoItem;

        }

        // GET: api/OrderPart/5
        [HttpGet("getspecificcount/{id}")]
        public int GetAsync2(int id)
        {
            var todoItem = _context.OrderPart.AsNoTracking().Where(s => s.PartId == id).ToList();

            return todoItem.Count;

        }


        // POST: api/OrderPart
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }


        // POST: api/<controller>
        [HttpPost("create")]
        public async Task<ActionResult<OrderPart>> CreateOrderPart([FromBody] OrderPart item)
        {
            try
            {
                _context.OrderPart.Add(item);
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

        // PUT: api/OrderPart/5
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
