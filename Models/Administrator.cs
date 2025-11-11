namespace SmartPark.Models;

public class Administrator
{
    public int AdministratorID { get; set; }
    public string? AdminName { get; set; }
    public string? AdminPassword { get; set; }

    // navigation to all models, since the administrator can access all of them

    public ICollection<UserSM>? UserSMs { get; set; }
    public ICollection<ParkingLot>? ParkingLots { get; set; }
    public ICollection<Reservation>? Reservations { get; set; }
    public ICollection<ParkingSpot>? ParkingSpots { get; set; }
}