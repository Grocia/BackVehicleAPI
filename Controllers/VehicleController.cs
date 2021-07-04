using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VehicleCreatorAPI.Models;

namespace BackVehicleAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class VehicleController : ControllerBase
    {
        
        [HttpPost]
        public ActionResult<ProcessVehicleResponse> ProcessVehicle([FromBody] VehicleRequest vehicleRequest)
        {
            //- Invalid, when any of the values is null or empty
            //-Valid in all other cases
            ProcessVehicleResponse processVehicleResponse;
            if(vehicleRequest.Type==null || ("").Equals(vehicleRequest.Type) ||
                vehicleRequest.ManufacturerNameShort == null || ("").Equals(vehicleRequest.ManufacturerNameShort) ||
                vehicleRequest.Price == null || ("").Equals(vehicleRequest.Price) ||
                vehicleRequest.VehicleId == null || ("").Equals(vehicleRequest.VehicleId))
            {
                processVehicleResponse = new ProcessVehicleResponse(0, VehicleValidationResultCode.Invalid);
            }
            else
            {
                VehicleRequesteList.Add(vehicleRequest);
                processVehicleResponse = new ProcessVehicleResponse(vehicleRequest.VehicleId, VehicleValidationResultCode.Valid);
            }
            
            return processVehicleResponse;
        }

        private static readonly List<VehicleRequest> VehicleRequesteList = new List<VehicleRequest>()
        {
            new VehicleRequest() { VehicleId = 1, Type = "Hatchback", ManufacturerNameShort = "Skoda", Price = 20000 },
            new VehicleRequest() { VehicleId = 2, Type = "Sedan", ManufacturerNameShort = "Apollo", Price = 20000 },
            new VehicleRequest() { VehicleId = 3, Type = "SUV", ManufacturerNameShort = "Acura", Price = 20000 },
            new VehicleRequest() { VehicleId = 4, Type = "Crossover", ManufacturerNameShort = "W Motors", Price = 20000 },
            new VehicleRequest() { VehicleId = 5, Type = "Coupe", ManufacturerNameShort = "Solaris", Price = 20000 },
            new VehicleRequest() { VehicleId = 6, Type = "Convertible", ManufacturerNameShort = "Ursus", Price = 20000 },
            new VehicleRequest() { VehicleId = 7, Type = "Hatchback", ManufacturerNameShort = "Dacia", Price = 20000 }
        };

        private readonly ILogger<VehicleController> _logger;

        public VehicleController(ILogger<VehicleController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<VehicleRequest> GetAll()
        {
            //var rng = new Random();
            //return Enumerable.Range(1, 5).Select(index => VehicleRequesteList[rng.Next(VehicleRequesteList.Count)]).ToArray();
            return VehicleRequesteList.ToArray();
        }

        /*[HttpPost]
        public VehicleRequest GetAt(int index)
        {
            return VehicleRequesteList.ElementAt(index);
        }*/
    }
}
