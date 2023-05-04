using FlightManagement.Abstractions.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagement.DataAccess
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private readonly BookingFlightsDbContext bookingFlightsDbContext;
        private IBookingRepository bookingRepository;
        private IFlightRepository flightRepository;
        private ISeatRepository seatRepository;
        private ITicketRepository ticketRepository;
        private IPassengerRepository passengerRepository;

        public IFlightRepository FlightRepository
        {
            get
            {
                if (flightRepository == null)
                {
                    flightRepository = new FlightRepository(bookingFlightsDbContext);
                }
                return flightRepository;
            }
        }
        public ISeatRepository SeatRepository
        {
            get
            {
                if (seatRepository == null)
                {
                    seatRepository = new SeatRepository(bookingFlightsDbContext);
                }
                return seatRepository;
            }
        }
        public ITicketRepository TicketRepository
        {
            get
            {
                if (ticketRepository == null)
                {
                    ticketRepository = new TicketRepository(bookingFlightsDbContext);
                }
                return ticketRepository;
            }
        }
        public IBookingRepository BookingRepository
        {
            get
            {
                if (bookingRepository == null)
                {
                    bookingRepository = new BookingRepository(bookingFlightsDbContext);
                }
                return bookingRepository;
            }
        }
        public IPassengerRepository PassengerRepository
        {
            get
            {
                if (passengerRepository == null)
                {
                    passengerRepository = new PassengerRepository(bookingFlightsDbContext);
                }
                return passengerRepository;
            }
        }
        public RepositoryWrapper(BookingFlightsDbContext dbContext)
        {
            bookingFlightsDbContext = dbContext;
        }

        public void Save()
        {
            bookingFlightsDbContext.SaveChanges();
        }
    }
}
