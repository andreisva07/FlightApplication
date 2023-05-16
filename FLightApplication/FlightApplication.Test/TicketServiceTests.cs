using FlightManagement.Abstractions.Repository;
using FlightManagement.AppLogic;
using FlightManagement.DataModel;
using Moq;
using System.Net.Sockets;


namespace FlightManagement.Test
{
    [TestClass]
    public class TicketServiceTests
    {
        private  Mock<IRepositoryWrapper> _repositoryWrapperMock;
        private  Mock<ITicketRepository> mockTicketRepository;
        private TicketService ticketService;

        [TestInitialize]
        public void SetUp()
        {
            _repositoryWrapperMock = new Mock<IRepositoryWrapper>();
            mockTicketRepository = new Mock<ITicketRepository>();
            _repositoryWrapperMock.Setup(x => x.TicketRepository).Returns(mockTicketRepository.Object);
            ticketService = new TicketService(_repositoryWrapperMock.Object);
        }
        [TestMethod]

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
        [TestMethod]

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

        [TestMethod]

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
        [TestMethod]

        public void GetTotalRevenue_ReturnsTotalRevenue()
        {
            // Arrange
            var totalRevenue = 1000m;
            var mockTicketRepository = new Mock<ITicketRepository>();
            mockTicketRepository.Setup(x => x.GetTotalRevenue()).Returns((int)totalRevenue);
            _repositoryWrapperMock.Setup(x => x.TicketRepository).Returns(mockTicketRepository.Object);
        }

        [TestMethod]
        public void GetByType_WhenCalled_ReturnsTicketsWithWantedType()
        {
            string test = "testType";
            List<TIcket> tickets = new List<TIcket>()
            {
              new TIcket {Id = 1, Type = test},
              new TIcket {Id = 2, Type = test},
              new TIcket {Id = 3, Type = "testType2" }
            };
            mockTicketRepository.Setup(x => x.GetByType(test))
                                .Returns(tickets.Where(x => x.Type == test).ToList());

            var result = ticketService.GetByType(test);

            Assert.AreEqual(2, result.Count());
            Assert.IsTrue(result.All(t => t.Type == test));
        }

        [TestMethod]

        public void TicketForFlight_WhenCalled_MarksTicketIdAsUnmodified()
        {
            TIcket ticket = new TIcket { Id = 1 };

            ticketService.TicketForFlight(ticket);

            mockTicketRepository.Verify(x => x.TicketForFlight(It.Is<TIcket>(t => t.Id == ticket.Id)), Times.Once);

            mockTicketRepository.Verify(x => x.Update(It.Is<TIcket>(t => t.Id == ticket.Id)), Times.Never);
        }
    }
}

