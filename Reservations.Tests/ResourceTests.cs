namespace Reservations.Tests;

public class ResourceTests
{
    [Fact]
    public void Reservation_will_be_made_when_resource_is_available()
    {
        // Reservation Enquiry
        var reservationTime = new Period(
         DateOnly.Parse("14-02-2023"), 
         TimeOnly.Parse("19:00"), 
         TimeOnly.Parse("20:00"));
        var customer = Customer.CreateNew("John Doe", new List<Reservation>());
        var reservationEnquiry = new ReservationEnquiry(reservationTime, customer, new Capacity(2));

        // Resource
        var resource = Resource.CreateNew(new Capacity(3), new List<Reservation>());
        
        resource.Reserve(reservationEnquiry);
    }
}