﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartMaintenanceWebApi.Models;

namespace SmartMaintenanceWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaintenancePartController : ControllerBase
    {

        private readonly MaintenancePartContext _context;

        public MaintenancePartController(MaintenancePartContext context)
        {
            this._context = context;
        }


        /*
        // GET: api/MaintenancePart
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/MaintenancePart/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }
        */

        // POST: api/<controller>
        [HttpPost("create")]
        public async Task<ActionResult<MaintenancePart>> CreateMaintenancePart([FromBody] MaintenancePart item)
        {
            try
            {
                _context.MaintenancePart.Add(item);
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

        // POST: api/MaintenancePart
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/MaintenancePart/5
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