using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagement.DataModel
{
    public class Seat : ModelEntity
    {
        public int Number { get; set; }

        public bool isAvailable { get; set; }

        public Guid FlightId { get; set; }

        public Flight Flight { get; set; }
    }
}
