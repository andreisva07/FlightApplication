using FlightManagement.Abstractions.Repository;
using FlightManagement.AppLogic;
using FlightManagement.DataModel;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagement.Test
{
    [TestClass]
    public class PassengerServiceTests
    {
        private Mock<IRepositoryWrapper> mockRepositoryWrapper;
        private PassengerService passengerService;
        
        [TestInitialize]
        public void Setup()
        {
            mockRepositoryWrapper = new Mock<IRepositoryWrapper>();
            passengerService = new PassengerService(mockRepositoryWrapper.Object);
        }

        [TestMethod]
        public void GetPassengersByTelephone_ShouldReturnListOfPassengers_WhenTelephoneIsValid()
        {
            string telephone = "1234567890";
            List<Passenger> passengers = new List<Passenger>
        {
            new Passenger { Id = 1, PassengerName = "John Doe", Email = "johndoe@example.com", Telephone = "1234567890" },
            new Passenger { Id = 2, PassengerName = "Jane Smith", Email = "janesmith@example.com", Telephone = "1234567890" }
        };
            mockRepositoryWrapper.Setup(x => x.PassengerRepository.GetPassengersByTelephone(telephone)).Returns(passengers);

            List<Passenger> result = passengerService.GetPassengersByTelephone(telephone);

            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count);
            Assert.AreEqual("John Doe", result[0].PassengerName);
            Assert.AreEqual("Jane Smith", result[1].PassengerName);
        }

        [TestMethod]
        public void GetPassengersByEmail_ShouldReturnListOfPassengers_WhenEmailIsValid()
        {
            string email = "johndoe@example.com";
            List<Passenger> passengers = new List<Passenger>
        {
            new Passenger { Id = 1, PassengerName= "John Doe", Email = "johndoe@example.com", Telephone = "1234567890" },
            new Passenger { Id = 3, PassengerName = "Jane Smith", Email = "janesmith@example.com", Telephone = "5551234567" }
        };
            mockRepositoryWrapper.Setup(x => x.PassengerRepository.GetPassengersByEmail(email)).Returns(passengers);

            List<Passenger> result = passengerService.GetPassengersByEmail(email);

            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count);
            Assert.AreEqual("John Doe", result[0].PassengerName);
            Assert.AreEqual("Jane Smith", result[1].PassengerName);
        }

        [TestMethod]
        public void GetPassengerById_Should_Return_Correct_Passenger_When_PassengerId_Exists()
        {
            
            int passengerId = 1;
            var mockPassenger = new Passenger { Id = passengerId, PassengerName = "John Doe", Email = "johndoe@example.com", Telephone = "1234567890" };

            mockRepositoryWrapper.Setup(x => x.PassengerRepository.GetPassengerById(passengerId))
                                 .Returns(mockPassenger);

            
            var result = passengerService.GetPassengerById(passengerId);

           
            Assert.AreEqual(passengerId, result.Id);
            Assert.AreEqual("John Doe", result.PassengerName);
            Assert.AreEqual("johndoe@example.com", result.Email);
            Assert.AreEqual("1234567890", result.Telephone);
        }
    }
}
