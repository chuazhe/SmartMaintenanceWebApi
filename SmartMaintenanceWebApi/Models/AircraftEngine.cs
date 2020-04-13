using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SmartMaintenanceWebApi.Models
{
    public class AircraftEngine
    {
        [Key]
        public int AircraftId { get; set; }
        public int EngineId { get; set; }
    }
}
