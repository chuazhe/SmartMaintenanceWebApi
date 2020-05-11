﻿using System;
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
    public class AircraftEngineController : Controller
    {

        private readonly AircraftEngineContext _context;

        public AircraftEngineController(AircraftEngineContext context)
        {
            this._context = context;

        }

        // GET: api/<controller>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AircraftEngine>>> GetAll()
        {
            return await _context.AircraftEngine.ToListAsync();
        }

        [HttpGet("getspecific/{id}")]
        public IEnumerable<AircraftEngine> GetAsync(int id)
        {
            var todoItem = _context.AircraftEngine.AsNoTracking().Where(s => s.AircraftId == id).ToList();

            return todoItem;

        }

        // POST: api/<controller>
        [HttpPost("create")]
        public async Task<ActionResult<EnginePart>> CreateEnginePart([FromBody] AircraftEngine item)
        {
            try
            {
                _context.AircraftEngine.Add(item);
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
        public async Task<ActionResult<EnginePart>> DeleteEnginePart([FromBody] AircraftEngine item)
        {
            try
            {
                //var todoItem = _context.EnginePart.AsNoTracking().Where(s => s.EngineId == item.EngineId && s.PartId==item.PartId);

                _context.AircraftEngine.Remove(item);
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
    }
}
