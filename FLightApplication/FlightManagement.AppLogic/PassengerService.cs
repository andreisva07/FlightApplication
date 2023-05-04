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

        public async Task SaveAsync()
        {
            await repositoryWrapper.PassengerRepository.SaveAsync();
        }
    }
}
