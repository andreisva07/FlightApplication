using FlightManagement.Abstractions.Repository;
using FlightManagement.AppLogic;
using FlightManagement.DataModel;
using Moq;


namespace FlightManagement.Test
{
    [TestClass]
    public class TicketServiceTests
    {
        private readonly Mock<IRepositoryWrapper> _repositoryWrapperMock;

        public TicketServiceTests()
        {
            _repositoryWrapperMock = new Mock<IRepositoryWrapper>();
        }


        public void CreateFromEntity_AddsTicketToRepository()
        {
            // Arrange
            var mockTicketRepository = new Mock<ITicketRepository>();
            _repositoryWrapperMock.Setup(x => x.TicketRepository).Returns(mockTicketRepository.Object);
            var ticketService = new TicketService(_repositoryWrapperMock.Object);
            var ticket = new TIcket { Id = 1, Type = "Economy" };

            // Act
            ticketService.CreateFromEntity(ticket);

            // Assert
            mockTicketRepository.Verify(x => x.Add(It.IsAny<TIcket>()), Times.Once);
        }

        public void UpdateFromEntity_UpdatesTicketInRepository()
        {
            // Arrange
            var mockTicketRepository = new Mock<ITicketRepository>();
            _repositoryWrapperMock.Setup(x => x.TicketRepository).Returns(mockTicketRepository.Object);
            var ticketService = new TicketService(_repositoryWrapperMock.Object);
            var ticket = new TIcket { Id = 1, Type = "Economy" };

            // Act
            ticketService.UpdateFromEntity(ticket);

            // Assert
            mockTicketRepository.Verify(x => x.Update(It.IsAny<TIcket>()), Times.Once);
        }


        public void DeleteFromEntity_DeletesTicketFromRepository()
        {
            // Arrange
            var mockTicketRepository = new Mock<ITicketRepository>();
            _repositoryWrapperMock.Setup(x => x.TicketRepository).Returns(mockTicketRepository.Object);
            var ticketService = new TicketService(_repositoryWrapperMock.Object);
            var ticket = new TIcket { Id = 1, Type = "Economy" };

            // Act
            ticketService.DeleteFromEntity(ticket);

            // Assert
            mockTicketRepository.Verify(x => x.Delete(It.IsAny<TIcket>()), Times.Once);
        }

        public void GetTotalRevenue_ReturnsTotalRevenue()
        {
            // Arrange
            var totalRevenue = 1000m;
            var mockTicketRepository = new Mock<ITicketRepository>();
            mockTicketRepository.Setup(x => x.GetTotalRevenue()).Returns((int)totalRevenue);
            _repositoryWrapperMock.Setup(x => x.TicketRepository).Returns(mockTicketRepository.Object);
        }
    }
}

