using FlightManagement.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagement.Abstractions.Repository
{
    public interface IPassengerRepository : IBaseRepository<Passenger>
    {
        public Passenger GetPassengerById(int passengerId);

        public List<Passenger> GetPassengersByEmail(string email);

        public List<Passenger> GetPassengersByTelephone(string telephone);
    }
}
