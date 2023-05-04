using FlightManagement.Abstractions.Repository;
using FlightManagement.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagement.DataAccess
{
    public class PassengerRepository :BaseRepository<Passenger>, IPassengerRepository
    {

        public PassengerRepository(BookingFlightsDbContext dbContext) : base(dbContext)
        {
        }
    }
}
