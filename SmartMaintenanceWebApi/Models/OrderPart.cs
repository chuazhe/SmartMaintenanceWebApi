using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SmartMaintenanceWebApi.Models
{
    public class OrderPart
    {
        [Key]
        public int OrderId { get; set; }

        public int PartId { get; set; }

        public int Quantity { get; set; }
    }
}
