using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SmartMaintenanceWebApi.Models
{
    public class EnginePart
    {
        public int EngineId { get; set; }
        public int PartId { get; set; }
    }
}
