using FlightManagement.Abstractions.Repository;
using FlightManagement.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagement.AppLogic
{
    public class FlightService
    {
        private readonly IRepositoryWrapper repositoryWrapper;
        public FlightService(IRepositoryWrapper repositoryWrapper) 
        {
            this.repositoryWrapper = repositoryWrapper;
        }
        public IQueryable<Flight> GetAllFlights()
        {
            return repositoryWrapper.FlightRepository.GetAll();
        }

        public void CreateFromEntity(Flight flight)
        {
            repositoryWrapper.FlightRepository.Add(flight);
        }

        public void UpdateFromEntity(Flight flight) 
        {
            repositoryWrapper.FlightRepository.Update(flight);
        }

        public void DeleteFromEntity(Flight flight) 
        {
            repositoryWrapper.FlightRepository.Delete(flight);
        }

        public IQueryable<Flight> SearchFlight(string departureCity, string arrivalCity, DateTime departureDate)
        {
            return repositoryWrapper.FlightRepository.SearchFlight(departureCity, arrivalCity, departureDate);
        }

        public void GetFlightsWithAvailableSeats() 
        {
            repositoryWrapper.FlightRepository.GetFlightsWithAvailableSeats();
        }
    }
}
