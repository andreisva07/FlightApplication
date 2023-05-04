using FlightManagement.Abstractions.Repository;
using FlightManagement.DataModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagement.DataAccess
{
    public class TicketRepository : BaseRepository<TIcket>, ITicketRepository
    {
        public TicketRepository(BookingFlightsDbContext dbContext) : base(dbContext) { }
        public TIcket Add(TIcket ticket)
        {
            var entity = dbContext.Set<TIcket>().Add(ticket);
            return entity.Entity;
        }
        public void Delete(TIcket ticket)
        {
            dbContext.Set<TIcket>().Remove(ticket);
        }

        public virtual IQueryable<TIcket> GetAll()
        {
            return dbContext.Set<TIcket>().AsNoTracking();
        }

        public TIcket GetById(Guid id)
        {
            return dbContext.Set<TIcket>().Single(x => x.Id == id);
        }

        public TIcket ChooseTicket(TIcket ticket)
        {
            var entity = dbContext.Set<TIcket>().Update(ticket);
            return entity.Entity;
        }
        public async Task SaveAsync()
        {
            await dbContext.SaveChangesAsync();
        }
        public void TicketForFlight(TIcket ticket)
        {
            dbContext.Entry(ticket).Property(x => x.Id).IsModified = false;
        }
    }
}
