using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartMaintenanceWebApi.Models
{
    public class Maintenance
    {
        public int MaintenanceId { get; set; }

        public int AircraftId { get; set; }

        public string MaintenanceDate { get; set; }

    }
}
