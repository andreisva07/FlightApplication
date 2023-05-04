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
        TIcket Add(TIcket ticket);
        TIcket ChooseTicket(TIcket ticket);
        void Delete(TIcket ticket);
        IQueryable<TIcket> GetAll();
        TIcket GetById(int id);
        Task SaveAsync();
        void TicketForFlight(TIcket ticket);
    }
}
