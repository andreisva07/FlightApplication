using FlightManagement.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagement.Abstractions.Repository
{
    public interface IBaseRepository<T> where T : ModelEntity
    {
        public T Add(T element);
        public void Delete(T element);
        public IQueryable<T> GetAll();
        public T GetById(int id);
        public Task SaveAsync();
        public T Update(T element);
    }
}
