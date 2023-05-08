using FlightManagement.Abstractions.Repository;
using FlightManagement.AppLogic;
using FlightManagement.DataModel;
using Moq;

namespace FlightManagement.Test
{
    [TestClass]
    public class BookingServiceTests
    {
        private Mock<IRepositoryWrapper> mockRepositoryWrapper;
        private BookingService bookingService;
        
        [TestInitialize]
        public void SetUp()
        {
            mockRepositoryWrapper = new Mock<IRepositoryWrapper>();
            bookingService = new BookingService(mockRepositoryWrapper.Object);
        }

        [TestMethod]
        public void FindEmail_Should_Return_Correct_Booking() 
        {
            Booking mockBooking = new Booking {Id = 1, UserName = "testuser@example.com"};

            mockRepositoryWrapper.Setup(x => x.BookingRepository.FindEmail(It.IsAny<string>()))
                                 .Returns(mockBooking);

            Booking result = bookingService.FindEmail("testuser@example.com");

            Assert.AreEqual(mockBooking, result);
        }

        [TestMethod]
        public void FindUser_Should_Return_Correct_Booking()
        {
            var mockBooking = new Booking { Id = 1, FlightId = 1, UserName = "testuser@example.com" };
           
            mockRepositoryWrapper.Setup(x => x.BookingRepository.FindUser(It.IsAny<int>(), It.IsAny<string>()))
                                 .Returns(mockBooking);

            var result = bookingService.FindUser(1, "testuser@example.com");

            Assert.AreEqual(mockBooking, result);
        }
    }
}
