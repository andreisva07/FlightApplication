using FlightManagement.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagement.Abstractions.Repository
{
    public interface IFlightRepository : IBaseRepository<Flight>
    {
        IQueryable<Flight> SearchFlight(string departureCity, string arrivalCity, DateTime departureDate);
    }
}
