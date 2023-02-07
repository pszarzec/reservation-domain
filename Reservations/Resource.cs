using Reservations.Exceptions;
using Reservations.Specifications;

namespace Reservations;

public class ResourceId : TypedId
{
    public int Value { get; set; }
}

public class Resource : IAggregateRoot, IEntity
{
    public ResourceId ResourceId { get; }
    
    private readonly Capacity _capacity;
    private readonly List<Reservation> _reservations;
    private readonly IEnumerable<ISpecification> _requiredSpecifications;

    public void Reserve(ReservationEnquiry enquiry)
    {
        var resourceProperties = new ResourceProperties(_capacity);
        
        var rejections = _requiredSpecifications
            .Select(specification => specification.IsSatisfied(enquiry, resourceProperties))
            .Where(result => result.Rejected)
            .ToList();

        if (rejections.Any())
        {
            throw new ReservationEnquiryRejectedException(rejections);
        }
        
        if (IsReservationPossible(enquiry))
        {
            var reservation = Reservation.CreateNew(enquiry.Customer, enquiry.Period);
            _reservations.Add(reservation);
        }
        else
        {
            throw new ResourceIsAlreadyReserved();
        }
    }
    private bool IsReservationPossible(ReservationEnquiry enquiry)
    {
        var askedPeriod = enquiry.Period;
        var overlapWithOtherReservations = _reservations
            .Where(x => x.IsAtDay(askedPeriod))
            .Any(x => x.IsOverlappingWith(askedPeriod));

        return !overlapWithOtherReservations;
    }
    
    public static Resource CreateNew(Capacity capacity, List<Reservation> reservations) => 
        new(capacity, reservations);

    private Resource(Capacity capacity, List<Reservation> reservations)
    {
        _capacity = capacity;
        _reservations = reservations;
        _requiredSpecifications = SpecificationsBuilder.BuildRequired();
    }
}