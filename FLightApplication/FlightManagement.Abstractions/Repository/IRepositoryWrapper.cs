using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagement.Abstractions.Repository
{
    public interface IRepositoryWrapper
    {
        public IBookingRepository BookingRepository { get; }
        public IFlightRepository FlightRepository { get; }
        public IPassengerRepository PassengerRepository { get; }
        public ISeatRepository SeatRepository { get; }
        public ITicketRepository TicketRepository { get; }

        void Save();
    }
}
