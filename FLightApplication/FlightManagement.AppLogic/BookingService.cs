using FlightManagement.Abstractions.Repository;
using FlightManagement.DataModel;

namespace FlightManagement.AppLogic
{
    public class BookingService
    {
        private readonly IRepositoryWrapper repositoryWrapper;

        public BookingService(IRepositoryWrapper repositoryWrapper)
        {
            this.repositoryWrapper = repositoryWrapper;
        }

        public IQueryable<Booking> GetAllBookings()
        {
            return repositoryWrapper.BookingRepository.GetAll();
        }

        public void CreateFromEntity(Booking booking)
        {
            repositoryWrapper.BookingRepository.Add(booking);
        }

        public void UpdateFromEntity(Booking booking)
        {
            repositoryWrapper.BookingRepository.Update(booking);
        }

        public void DeleteFromEntity(Booking booking)
        {
            repositoryWrapper.BookingRepository.Delete(booking);
        }

        public Booking FindUser(int flightId, string userName)
        {
            return repositoryWrapper.BookingRepository.FindUser(flightId, userName);
        }

        public Booking FindEmail(string userEmail)
        {
            return repositoryWrapper.BookingRepository.FindEmail(userEmail);
        }

        public async Task SaveAsync()
        {
            await repositoryWrapper.BookingRepository.SaveAsync();
        }
    }
}