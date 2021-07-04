using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VehicleCreatorAPI.Models
{
    public class ProcessVehicleResponse
    {
        //The VehicleId should remain the same, the ReturnCode should return possible states(Enum), Valid, Invalid, NotSpecified(as default).
        public int VehicleId { get; set; }
        public VehicleValidationResultCode ReturnCode { get; set; }

        public ProcessVehicleResponse()
        {
            VehicleId = 0;
            ReturnCode = VehicleValidationResultCode.NotSpecified;
        }

        public ProcessVehicleResponse(int VehicleId, VehicleValidationResultCode ReturnCode)
        {
            this.VehicleId = VehicleId;
            this.ReturnCode = ReturnCode;
        }

    }
    
    public enum VehicleValidationResultCode
    {
        NotSpecified,
        Invalid,
        Valid
    }
}
