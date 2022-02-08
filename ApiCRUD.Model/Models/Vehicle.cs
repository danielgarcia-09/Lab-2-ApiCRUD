using ApiCRUD.Models;

namespace ApiCRUD
{

    public class Vehicle
    {
        public int Id { get; set; }

        public string Brand { get; set; }

        public int WheelSize { get; set; }

        public bool IsOn { get; set; }

        public int VehicleType { get; set; }

        public int OwnerId { get; set; }
        public virtual Owner Owner { get; set; }

    }


}
