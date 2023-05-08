using FlightManagement.Abstractions.Repository;
using FlightManagement.AppLogic;
using FlightManagement.DataModel;
using Moq;

namespace FlightManagement.Test
{
    [TestClass]
    public class FlightServiceTests
    {
        private Mock<IRepositoryWrapper> mockRepositoryWrapper;
        private FlightService flightService;
        
        [TestInitialize]
        public void SetUp()
        {
            mockRepositoryWrapper = new Mock<IRepositoryWrapper>();
            flightService = new FlightService(mockRepositoryWrapper.Object);
        }

        [TestMethod]
        public void SearchFlight_Should_Return_Correct_Flights()
        {
            var mockFlights = new List<Flight>
        {
            new Flight { Id = 1, DepartureCity = "New York", ArrivalCity = "Los Angeles", departureDate = new DateTime(2023, 05, 10) },
            new Flight { Id = 2, DepartureCity = "Los Angeles", ArrivalCity = "New York", departureDate = new DateTime(2023, 05, 10) },
            new Flight { Id = 3, DepartureCity= "Chicago", ArrivalCity = "Houston", departureDate = new DateTime(2023, 05, 11) }
        };
            mockRepositoryWrapper.Setup(x => x.FlightRepository.SearchFlight(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<DateTime>()))
                                 .Returns((string departureCity, string arrivalCity, DateTime departureDate) => mockFlights
                                 .Where(x => x.DepartureCity == departureCity && 
                                             x.ArrivalCity == arrivalCity && 
                                             x.departureDate.Date == departureDate.Date).AsQueryable());

            var result = flightService.SearchFlight("New York", "Los Angeles", new DateTime(2023, 05, 10)).ToList();
            Assert.AreEqual(1, result.Count);
            Assert.AreEqual(1, result[0].Id);

            result = flightService.SearchFlight("Chicago", "Houston", new DateTime(2023, 05, 11)).ToList();
            Assert.AreEqual(1, result.Count);
            Assert.AreEqual(3, result[0].Id);
        }
    }
}
