namespace SmartPark.Models;

    public class Reservation
    {
        public int ReservationID { get; set; }
        public int UserSMId { get; set; }
        public int ParkingSpotID { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }

        // Navigation properties
        public UserSM? UserSM { get; set; }
        public ParkingSpot? ParkingSpot { get; set; }
    }