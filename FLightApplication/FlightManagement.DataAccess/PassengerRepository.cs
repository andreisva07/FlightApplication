using FlightManagement.Abstractions.Repository;
using FlightManagement.DataModel;

namespace FlightManagement.DataAccess
{
    public class PassengerRepository :BaseRepository<Passenger>, IPassengerRepository
    {

        public PassengerRepository(BookingFlightsDbContext dbContext) : base(dbContext) {}
        public Passenger GetPassengerById(int passengerId)
        {
            return dbContext.Passengers.Single(x => x.Id == passengerId);
        }

        public List<Passenger> GetPassengersByEmail(string email)
        {
            return dbContext.Passengers.Where(x => x.Email == email).ToList();
        }

        public List<Passenger> GetPassengersByTelephone(string telephone)
        {
            return dbContext.Passengers.Where(x => x.Telephone== telephone).ToList();
        }
    }
}
