using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartMaintenanceWebApi.Models
{
    public class Order
    {
        public int OrderId { get; set; }

        public string OrderDate { get; set; }

        public string OrderApproveDate { get; set; }

        public int OrderApprove { get; set; }


    }
}
