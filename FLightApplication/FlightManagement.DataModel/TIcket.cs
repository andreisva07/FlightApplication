namespace FlightManagement.DataModel
{
    public class TIcket : ModelEntity
    {
        public string Type { get; set; }

        public int Price { get; set; }

        public int FlightId { get; set; }
    }
}
