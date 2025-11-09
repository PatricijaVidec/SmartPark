namespace SmartPark.Models;

public class ParkingLot
{
    public int ParkingLotID { get; set; }
    public string? Location { get; set; }
    public int Capacity { get; set; }

    // Navigation property
    public ICollection<ParkingSpot>? ParkingSpots { get; set; }
}