using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Autowont.Models
{
    public class SearchModel
    {
        public State state { get; set; }
        //public City city { get; set; }
        public Brand brand { get; set; }
        public CarModel carmodel { get; set; }
        public Colors color { get; set; }
        public BodyType bodyType { get; set; }
        public Transmission transmission { get; set; }
        public DriveType driveType { get; set; }
        public FuelType fuelType { get; set; }
    }
}
