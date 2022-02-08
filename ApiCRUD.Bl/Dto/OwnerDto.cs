using System.Collections.Generic;

namespace ApiCRUD.Bl.Dto
{
    public class OwnerDto : BaseDto
    {

        public string Name { get; set; }

        public string LastName { get; set; }

        public string Identification { get; set; }

        public List<VehicleDto> Vehicles { get; set; } = new List<VehicleDto>();
    }
}
