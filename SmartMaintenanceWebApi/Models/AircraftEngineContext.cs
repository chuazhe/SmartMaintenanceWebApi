using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartMaintenanceWebApi.Models
{
    public class AircraftEngineContext : DbContext
    {

        //For OnConfiguring
        public AircraftEngineContext()
        {
        }

        //Initiliase the context with the connection string in appsettings.json (RMB to put the configure the service 1st in Starup.cs!)
        public AircraftEngineContext(DbContextOptions<AircraftEngineContext> options) : base(options)
        { }

        //The object for the context
        public DbSet<AircraftEngine> AircraftEngine { get; set; }


        /*
        // For scaffolded purpose
        Configuration Conventions
        A Configuration Convention is a way to configure entities without overriding the default behavior provided in the Fluent API.
        You can define a configuration convention in the OnModelCreating() method and also in a custom class
        , similar to how you would define normal entity mappings with Fluent API. Used to to define the attributes (PK,FK,NOT NULL,...) in code-first approach.
             */
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}
