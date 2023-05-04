using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagement.DataModel
{
    public class Flight : ModelEntity
    {
        public string Name { get; set; }

        public string DepartureCity { get; set; }
        
        public string ArrivalCity { get; set; }

        public DateTime departureDate { get; set; }

        public DateTime arrivalDate { get; set; }

        public ICollection<Seat> Seats = new List<Seat>(40);

    }
}
