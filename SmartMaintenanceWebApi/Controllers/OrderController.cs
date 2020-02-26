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
    public class OrderController : Controller
    {

        private readonly OrderContext _context;

        public OrderController(OrderContext context)
        {
            this._context = context;
        }


        // GET: api/<controller>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Order>>> GetAll()
        {
            return await _context.Order.ToListAsync();
        }

        /*
        // GET: api/Order
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
        */

        /*
    // GET: api/Order/5
    [HttpGet("{id}", Name = "Get")]
    public string Get(int id)
    {
        return "value";
    }
    */

        // POST: api/Order
        /*
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }
        */

        // GET: api/OrderPart/5
        [HttpGet("getspecific/{id}")]
        public IEnumerable<Order> GetAsync(int id)
        {
            var todoItem = _context.Order.Where(s => s.OrderId == id).ToList();

            return todoItem;

        }


        // GET: api/OrderPart/5
        [HttpGet("getapproved")]
        public IEnumerable<Order> GetApproved(int id)
        {
            var todoItem = _context.Order.Where(s => s.OrderApprove == 1).ToList();

            return todoItem;

        }

        // GET: api/OrderPart/5
        [HttpGet("getunapproved")]
        public IEnumerable<Order> GetUnApproved(int id)
        {
            var todoItem = _context.Order.Where(s => s.OrderApprove == 0).ToList();

            return todoItem;

        }

        // POST: api/<controller>
        [HttpPost("create")]
        public async Task<ActionResult<Order>> CreateOrder([FromBody] Order item)
        {
            try
            {
                item.OrderId=getTopId() + 1;
                _context.Order.Add(item);
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
            var x = _context.Order.Last().OrderId;
            return x;
        }

        // PUT: api/Order/5
        [HttpPut("approve/{id}/{date}")]
        public async Task<IActionResult> ApproveAsync(int id, string date)
        {

            var todoItem = await _context.Order.FindAsync(id);

            if (todoItem != null)
            {

                todoItem.OrderApprove = 1;
                todoItem.OrderApproveDate = date;
                _context.Entry(todoItem).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                return Ok();
            }
            return NotFound();

        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
