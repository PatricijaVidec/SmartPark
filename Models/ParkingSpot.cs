namespace SmartPark.Models;

public class ParkingSpot
{
    public int ParkingSpotID { get; set; }
    public int ParkingLotID { get; set; }
    public bool IsOccupied { get; set; }

    // Navigation property
    public ParkingLot? ParkingLot { get; set; } // it can't be null, remove after
}