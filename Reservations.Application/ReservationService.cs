using Reservations.Persistence;

namespace Reservations.Application;

/// <summary>
/// Example of Application service that use domain model.
/// </summary>
public class ReservationService
{
    private readonly ReservationsDbContext _reservationsDbContext;

    public ReservationService(ReservationsDbContext reservationsDbContext)
    {
        _reservationsDbContext = reservationsDbContext;
    }

    public async Task MakeReservation(ReservationRequest request)
    {
        var customer = await _reservationsDbContext.Customers.FindAsync(request.CustomerId);
        // validation check
        
        // Concrete settings for a restaurant belonging to a specific tenant. 
        // Take from tenant settings/properties.
        const int ReservationDurationMinutes = 60;

        var startsAt = TimeOnly.FromDateTime(request.DateAndTime);
        var endsAt = TimeOnly.FromDateTime(request.DateAndTime).AddMinutes(ReservationDurationMinutes);
        var period = new Period(DateOnly.FromDateTime(request.DateAndTime), startsAt, endsAt);
        var reservationEnquiry = new ReservationEnquiry(period, customer, new Capacity(2));

        // Here it is the case that we are reserving a specific resource
        // (e.g. we have tables shown on the user interface and can select a specific one)
        var resource = await _reservationsDbContext.Resources.FindAsync(request.ResourceId);
        // validation check, if not exists, create new one, but take into account what tables are available in a particular restaurant

        try
        {
            resource.Reserve(reservationEnquiry);
            
            // Here we can take domain events from resource (assuming that each aggregate returns domain events)
            // and execute them - one of the event: ReservationCreated can be handle by handler that will
            // check invariant("A customer can only have one reservation at the same time.") on Customer aggregate.
        }
        catch
        {
            // handle domain errors
        }

        await _reservationsDbContext.SaveChangesAsync();
    }
}