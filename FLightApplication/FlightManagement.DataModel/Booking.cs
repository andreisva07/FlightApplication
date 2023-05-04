namespace FlightManagement.DataModel
{
    public class Booking : ModelEntity
    {
        public string UserName { get; set; }
        
        public int FlightId { get; set; }

        public int SeatId { get; set;}

        public int TicketId { get; set; }
    }
}