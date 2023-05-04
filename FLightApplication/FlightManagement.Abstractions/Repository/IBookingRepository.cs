using FlightManagement.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagement.Abstractions.Repository
{
    public interface IBookingRepository : IBaseRepository<Booking>
    {
        Booking FindEmail(string userEmail);
        Booking FindUser(int flightId, string userName);

    }
}
