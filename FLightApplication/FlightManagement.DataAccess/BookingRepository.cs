using FlightManagement.Abstractions.Repository;
using FlightManagement.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagement.DataAccess
{
    public class BookingRepository : BaseRepository<Booking>, IBookingRepository
    {
        public BookingRepository(BookingFlightsDbContext dbContext) : base(dbContext)
        {
        }
        public Booking FindEmail(string userEmail)
        {
            return dbContext.Bookings.First(x => x.UserName == userEmail);
        }
        public Booking FindUser(Guid flightId, string userName)
        {
            return dbContext.Bookings.First(x => x.FlightId == flightId && x.UserName == userName);
        }
    }
}
