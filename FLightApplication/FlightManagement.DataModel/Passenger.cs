namespace FlightManagement.DataModel
{
    public class Passenger : ModelEntity
    {
        public string PassengerName { get; set; }

        public string PassengerSurname { get; set; }

        public string Email { get; set; }

        public string Telephone { get; set; }
    }
}
