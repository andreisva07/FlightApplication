using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagement.Abstractions.Repository
{
    public interface IRepositoryWrapper
    {
        IBookingRepository BookingRepository { get; }
        IFlightRepository FlightRepository { get; }
        IPassengerRepository PassengerRepository { get; }
        ISeatRepository SeatRepository { get; }
        ITicketRepository TicketRepository { get; }

        void Save();
    }
}
