using FlightManagement.Abstractions.Repository;
using FlightManagement.DataModel;

namespace FlightManagement.AppLogic
{
    public class TicketService
    {
        private readonly IRepositoryWrapper repositoryWrapper;
        
        public TicketService(IRepositoryWrapper repositoryWrapper)
        {
            this.repositoryWrapper = repositoryWrapper;
        }

        public IQueryable<TIcket> GetAllTickets(TIcket ticket)
        {
           return repositoryWrapper.TicketRepository.GetAll();
        }

        public void CreateFromEntity(TIcket ticket)
        {
            repositoryWrapper.TicketRepository.Add(ticket);
        }

        public void UpdateFromEntity(TIcket ticket)
        {
            repositoryWrapper.TicketRepository.Update(ticket);
        }

        public void DeleteFromEntity(TIcket ticket)
        {
            repositoryWrapper.TicketRepository.Delete(ticket);
        }
        public void GetTotalRevenue() 
        {
            repositoryWrapper.TicketRepository.GetTotalRevenue();
        }

        public List<TIcket> GetByType(string type)
        {
            return repositoryWrapper.TicketRepository.GetByType(type).ToList();
        }

        public void TicketForFlight(TIcket ticket)
        {
            repositoryWrapper.TicketRepository.TicketForFlight(ticket);
        }

        public async Task SaveAsync()
        {
            await repositoryWrapper.TicketRepository.SaveAsync();
        }
    } 
}
