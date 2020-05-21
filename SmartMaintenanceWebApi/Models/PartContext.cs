using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace SmartMaintenanceWebApi.Models
{
    public class PartContext : DbContext
    {
        //For OnConfiguring
        public PartContext()
        {
        }

        //Initiliase the context with the connection string in appsettings.json (RMB to put the configure the service 1st in Starup.cs!)
        public PartContext(DbContextOptions<PartContext> options) : base(options)
        { }

        //The object for the context
        public DbSet<Part> Part { get; set; }


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

