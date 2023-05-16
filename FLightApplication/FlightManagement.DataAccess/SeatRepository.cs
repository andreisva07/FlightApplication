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

        public List<Seat> GetAvailableSeats(int flightid)
        {
            return dbContext.Seats.Where(x => x.FlightId == flightid && x.isAvailable == true).ToList();
        }

        public Seat GetSeatByNumber(int seatnumber)
        {
            return dbContext.Seats.First(x => x.Number == seatnumber);
        }
        
        public int SeatAvailability(int seatnumber)
        {
            Seat seat = GetSeatByNumber(seatnumber);
            if(seat != null)
            {
                seat.isAvailable= false;
                Update(seat);
            }
            return seatnumber;
            
        }
    }
}
