using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagement.DataModel
{
    public class TIcket : ModelEntity
    {
        public string Type { get; set; }

        public int Price { get; set; }

        public Guid FlightId { get; set; }
    }
}
