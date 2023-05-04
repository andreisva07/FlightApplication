namespace FlightManagement.DataModel
{
    public class Seat : ModelEntity
    {
        public int Number { get; set; }

        public bool isAvailable { get; set; }

        public int FlightId { get; set; }

        public Flight Flight { get; set; }
    }
}
