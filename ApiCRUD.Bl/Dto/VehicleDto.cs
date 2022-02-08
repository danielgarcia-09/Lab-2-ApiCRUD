using ApiCRUD.Bl.Enum;

namespace ApiCRUD.Bl.Dto
{
    public class VehicleDto : BaseDto
    {
        public string Brand { get; set; }
        public int WheelSize { get; set; }
        public VehicleEnum VehicleType { get; set; }
        public bool IsOn { get; set; }
        
        public int OwnerId { get; set; }

        public void TurnOnOff() { this.IsOn = !this.IsOn; }
    }
}
