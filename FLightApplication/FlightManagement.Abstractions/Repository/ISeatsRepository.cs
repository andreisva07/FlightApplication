using FlightManagement.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagement.Abstractions.Repository
{
    public interface ISeatRepository : IBaseRepository<Seat>
    {
        void SeatForFlight(Seat seat);

        public List<Seat> GetAvailableSeats(int flightid);

        public Seat GetSeatByNumber(int seatnumber);

        public int SeatAvailability(int seatnumber);
    }
}
