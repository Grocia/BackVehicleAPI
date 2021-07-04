using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VehicleCreatorAPI.Models
{
    public class VehicleRequest
    {
        public int VehicleId { get; set; }
        public string Type { get; set; }
        public string ManufacturerNameShort { get; set; }
        public decimal Price { get; set; }

    }


}
