using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SmartMaintenanceWebApi.Models
{
    public class MaintenancePart
    {
        [Key]
        public int MaintenanceId { get; set; }

        public int PartId { get; set; }

        public int PartCount { get; set; }
    }
}
