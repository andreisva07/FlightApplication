using FlightManagement.DataModel;
using Microsoft.EntityFrameworkCore;

namespace FlightManagement.DataAccess
{
    public class BookingFlightsDbContext : DbContext
    {
        public BookingFlightsDbContext(DbContextOptions<BookingFlightsDbContext> dbContext) : base(dbContext) { }

        public DbSet<Booking> Bookings { get; set; }

        public DbSet<Flight> Flights { get; set; }
        
        public DbSet<Passenger> Passengers { get; set; }

        public DbSet<TIcket> TIckets { get; set; }

        public DbSet<Seat> Seats { get; set; }
        public DbSet<FlightManagement.DataModel.Flight> Flight { get; set; } = default!;
        public DbSet<FlightManagement.DataModel.Passenger> Passenger { get; set; } = default!;
        public DbSet<FlightManagement.DataModel.TIcket> TIcket { get; set; } = default!;
        public DbSet<FlightManagement.DataModel.Booking> Booking { get; set; } = default!;
    }
}
