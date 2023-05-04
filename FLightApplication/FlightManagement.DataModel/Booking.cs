namespace FlightManagement.DataModel
{
    public class Booking : ModelEntity
    {
        public string UserName { get; set; }
        
        public Guid FlightId { get; set; }

        public Guid SeatId { get; set;}

        public Guid TicketId { get; set; }
    }
}