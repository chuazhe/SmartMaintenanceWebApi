using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartMaintenanceWebApi.Models;


namespace SmartMaintenanceWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AircraftController : Controller
    {

        private readonly AircraftContext _context;

        public AircraftController(AircraftContext context)
        {
            this._context = context;

        }

        // GET: api/<controller>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Aircraft>>> GetAll()
        {
            return await _context.Aircraft.ToListAsync();
        }

        [HttpPut("maintenance/{id}")]
        public async Task<IActionResult> MaintenanceAsync(int id)
        {

            var todoItem = await _context.Aircraft.FindAsync(id);

            if (todoItem != null)
            {

                todoItem.AircraftStatus = 0;
                _context.Entry(todoItem).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                return Ok();
            }
            return NotFound();

        }

        [HttpPut("service/{id}")]
        public async Task<IActionResult> ServiceAsync(int id)
        {

            var todoItem = await _context.Aircraft.FindAsync(id);

            if (todoItem != null)
            {

                todoItem.AircraftStatus = 1;
                _context.Entry(todoItem).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                return Ok();
            }
            return NotFound();

        }
    }
}
