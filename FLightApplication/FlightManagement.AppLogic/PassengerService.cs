using FlightManagement.Abstractions.Repository;
using FlightManagement.DataModel;

namespace FlightManagement.AppLogic
{
    public class PassengerService
    {
        private readonly IRepositoryWrapper repositoryWrapper;

        public PassengerService(IRepositoryWrapper repositoryWrapper) 
        {
            this.repositoryWrapper = repositoryWrapper;
        }

        public IQueryable<Passenger> GetAllPassengers()
        {
            return repositoryWrapper.PassengerRepository.GetAll();
        }

        public void CreateFromEntity(Passenger passenger)
        {
            repositoryWrapper.PassengerRepository.Add(passenger);
        }

        public void DeleteFromEntity(Passenger passenger)
        {
            repositoryWrapper.PassengerRepository.Delete(passenger);
        }

        public void UpdateFromEntity(Passenger passenger)
        {
            repositoryWrapper.PassengerRepository.Update(passenger);
        }

        public Passenger GetPassengerById(int passengerId)
        {
            return repositoryWrapper.PassengerRepository.GetPassengerById(passengerId);
        }
        
        public List<Passenger> GetPassengersByEmail(string email)
        {
            return repositoryWrapper.PassengerRepository.GetPassengersByEmail(email);
        }

        public List<Passenger> GetPassengersByTelephone(string telephone)
        {
            return repositoryWrapper.PassengerRepository.GetPassengersByTelephone(telephone);
        }

        public async Task SaveAsync()
        {
            await repositoryWrapper.PassengerRepository.SaveAsync();
        }
    }
}
