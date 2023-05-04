using FlightManagement.Abstractions.Repository;
using FlightManagement.DataModel;

namespace FlightManagement.AppLogic
{
    public class SeatService
    {
        private readonly IRepositoryWrapper repositoryWrapper;
        
        public SeatService(IRepositoryWrapper repositoryWrapper)
        {
            this.repositoryWrapper = repositoryWrapper;
        }

        public IQueryable<Seat> GetAllSeats()
        {
            return repositoryWrapper.SeatRepository.GetAll();
        }
        public void CreateFromEntity(Seat seat)
        {
            repositoryWrapper.SeatRepository.Add(seat);
        }

        public void UpdateFromEntity(Seat seat) 
        {
            repositoryWrapper.SeatRepository.Update(seat);
        }

        public void DeleteFromEntity(Seat seat) 
        {
            repositoryWrapper.SeatRepository.Delete(seat);
        }

        public void SeatForFlight(Seat seat)
        {
            repositoryWrapper.SeatRepository.SeatForFlight(seat);
        }

        public void GetAvailableSeats(int flightid)
        {
            repositoryWrapper.SeatRepository.GetAvailableSeats(flightid);
        }
        public void GetSeatByNumber(int seatnumber)
        {
            repositoryWrapper.SeatRepository.GetSeatByNumber(seatnumber);
        }

        public void SeatAvailability(int seatnumber) 
        {
            repositoryWrapper.SeatRepository.SeatAvailability(seatnumber);
        }

        public async Task SaveAsync()
        {
            await repositoryWrapper.SeatRepository.SaveAsync();
        }
    }
}
