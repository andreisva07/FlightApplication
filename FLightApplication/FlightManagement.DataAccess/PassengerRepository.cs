using FlightManagement.Abstractions.Repository;
using FlightManagement.DataModel;

namespace FlightManagement.DataAccess
{
    public class PassengerRepository :BaseRepository<Passenger>, IPassengerRepository
    {

        public PassengerRepository(BookingFlightsDbContext dbContext) : base(dbContext)
        {
        }
    }
}
