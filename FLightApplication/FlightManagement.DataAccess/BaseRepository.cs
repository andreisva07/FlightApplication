using FlightManagement.Abstractions.Repository;
using FlightManagement.DataModel;
using Microsoft.EntityFrameworkCore;

namespace FlightManagement.DataAccess
{
    public class BaseRepository<T> : IBaseRepository<T> where T : ModelEntity
    {
        protected readonly BookingFlightsDbContext dbContext;

        public BaseRepository(BookingFlightsDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public virtual IQueryable<T> GetAll()
        {
            return dbContext.Set<T>().AsNoTracking();
        }

        public T Add(T element)
        {
            var entity = dbContext.Set<T>().Add(element).Entity;
            return entity;
        }
        public void Delete(T element)
        {
            this.dbContext.Set<T>().Remove(element);
        }
        public T Update(T element)
        {
            var entity = dbContext.Set<T>().Update(element).Entity;
            return entity;
        }
        public T GetById(Guid id)
        {
            return dbContext.Set<T>().Single(x => x.Id == id);
        }
        public async Task SaveAsync()
        {
            await dbContext.SaveChangesAsync();
        }
    }
}