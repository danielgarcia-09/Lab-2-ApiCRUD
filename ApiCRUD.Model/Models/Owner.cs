using System.Collections.Generic;

namespace ApiCRUD.Models
{
    public class Owner
    {
        public int Id { get; set; } 

        public string Name { get; set; }

        public string LastName { get; set; }

        public string Identification { get; set; }

        public virtual ICollection<Vehicle> Vehicles { get; set; }
    }
}
