using FlightManagement.Abstractions.Repository;
using FlightManagement.DataModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagement.DataAccess
{
    public class FlightRepository : BaseRepository<Flight>, IFlightRepository
    {
        public FlightRepository(BookingFlightsDbContext dbContext) : base(dbContext) { }

        public IQueryable<Flight> SearchFlight(string departureCity, string arrivalCity, DateTime departureDate)
        {
            return dbContext.Flights.Where(x => x.DepartureCity == departureCity)
                .Where(x => x.ArrivalCity == arrivalCity)
                .Where(x => x.departureDate.Date == departureDate.Date);
        }
    }
}
