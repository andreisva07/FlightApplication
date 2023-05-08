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
        public IQueryable<Flight> SearchFlight(string departureCity, string arrivalCity, DateTime departureDate);

        public IQueryable<Flight> GetFlightsWithAvailableSeats();

    }
}
