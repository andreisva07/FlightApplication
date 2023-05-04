using FlightManagement.Abstractions.Repository;
using FlightManagement.DataModel;

namespace FlightManagement.DataAccess
{
    public class SeatRepository : BaseRepository<Seat> ,ISeatRepository
    {
        public SeatRepository(BookingFlightsDbContext dbContext) : base(dbContext) { }

        public void SeatForFlight(Seat seat)
        {
            dbContext.Entry(seat).Property(x => x.Flight).IsModified = false;
        }
    }
}
