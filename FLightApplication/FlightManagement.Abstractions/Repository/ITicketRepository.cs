using FlightManagement.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagement.Abstractions.Repository
{
    public interface ITicketRepository : IBaseRepository<TIcket>
    {
        public TIcket Add(TIcket ticket);

        public TIcket ChooseTicket(TIcket ticket);

        public void Delete(TIcket ticket);

        public IQueryable<TIcket> GetAll();

        public TIcket GetById(int id);

        public Task SaveAsync();

        public int GetTotalRevenue();

        public IQueryable<TIcket> GetByType(string type);

        public void TicketForFlight(TIcket ticket);
    }
}
