using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SmartMaintenanceWebApi.Models
{
    public class AircraftPart
    {
        [Key]
        public int AircraftId { get; set; }

        public int PartId { get; set; }

    }
}
