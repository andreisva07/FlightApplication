using FlightManagement.Abstractions.Repository;
using FlightManagement.DataModel;

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

        public IQueryable<Flight> GetFlightsWithAvailableSeats()
        {
            return GetAll().Where(x => x.Seats.Count < 40);
        }
    }
}
