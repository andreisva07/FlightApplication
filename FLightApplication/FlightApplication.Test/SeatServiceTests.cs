using FlightManagement.Abstractions.Repository;
using FlightManagement.AppLogic;
using FlightManagement.DataModel;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagement.Test
{
    [TestClass]
    public class SeatServiceTests
    {
        private Mock<IRepositoryWrapper> _repositoryWrapperMock;
        private SeatService seatService;

        [TestInitialize]
        public void Setup()
        {
            _repositoryWrapperMock = new Mock<IRepositoryWrapper>();
            seatService = new SeatService(_repositoryWrapperMock.Object);
        }

        public void GetAllSeats_ReturnsAllSeats()
        {
            // Arrange
            var seats = new List<Seat> { new Seat(), new Seat(), new Seat() }.AsQueryable();
            _repositoryWrapperMock.Setup(x => x.SeatRepository.GetAll()).Returns(seats);
            var service = new SeatService(_repositoryWrapperMock.Object);

            // Act
            var result = service.GetAllSeats();

            // Assert
            Assert.Equals(seats, result);
        }
        public void CreateFromEntity_AddsSeat()
        {
            // Arrange
            var seat = new Seat();
            _repositoryWrapperMock.Setup(x => x.SeatRepository.Add(seat));
            var service = new SeatService(_repositoryWrapperMock.Object);

            // Act
            service.CreateFromEntity(seat);

            // Assert
            _repositoryWrapperMock.Verify(x => x.SeatRepository.Add(seat), Times.Once);
        }

        public void UpdateFromEntity_UpdatesSeat()
        {
            // Arrange
            var seat = new Seat();
            _repositoryWrapperMock.Setup(x => x.SeatRepository.Update(seat));
            var service = new SeatService(_repositoryWrapperMock.Object);

            // Act
            service.UpdateFromEntity(seat);

            // Assert
            _repositoryWrapperMock.Verify(x => x.SeatRepository.Update(seat), Times.Once);
        }

        public void DeleteFromEntity_DeletesSeat()
        {
            // Arrange
            var seat = new Seat();
            _repositoryWrapperMock.Setup(x => x.SeatRepository.Delete(seat));
            var service = new SeatService(_repositoryWrapperMock.Object);

            // Act
            service.DeleteFromEntity(seat);

            // Assert
            _repositoryWrapperMock.Verify(x => x.SeatRepository.Delete(seat), Times.Once);
        }

        public void SeatForFlight_AddsSeatToFlight()
        {
            // Arrange
            var seat = new Seat();
            _repositoryWrapperMock.Setup(x => x.SeatRepository.SeatForFlight(seat));
            var service = new SeatService(_repositoryWrapperMock.Object);

            // Act
            service.SeatForFlight(seat);

            // Assert
            _repositoryWrapperMock.Verify(x => x.SeatRepository.SeatForFlight(seat), Times.Once);
        }

        public void GetSeatByNumber_ReturnsSeatWithMatchingNumber()
        {
            // Arrange
            var seatNumber = 123;
            var seat = new Seat { Number = seatNumber };
            _repositoryWrapperMock.Setup(x => x.SeatRepository);
            }

        [TestMethod]
        public void GetSeatByNumber_Should_Return_Correct_Seat_When_SeatNumber_Exists()
        {
            
            int seatNumber = 42;
            var mockSeat = new Seat { Number = seatNumber };

            _repositoryWrapperMock.Setup(x => x.SeatRepository.GetSeatByNumber(seatNumber)).Returns(mockSeat);

            
            var result = seatService.GetSeatByNumber(seatNumber);

            
            Assert.IsNotNull(result);
            Assert.AreEqual(seatNumber, result.Number);
            
        }

        [TestMethod]
        public void SeatAvailability_Should_Update_Seat_Availability_When_SeatNumber_Exists()
        {
            
            int seatNumber = 42;
            var mockSeat = new Seat { Number = seatNumber, isAvailable = false };

            _repositoryWrapperMock.Setup(x => x.SeatRepository.GetSeatByNumber(seatNumber)).Returns(mockSeat);

            
            seatService.SeatAvailability(seatNumber);

            Assert.IsFalse(mockSeat.isAvailable);
        }

    }
}
