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
        T Add(T element);
        void Delete(T element);
        IQueryable<T> GetAll();
        T GetById(Guid id);
        Task SaveAsync();
        T Update(T element);
    }
}
