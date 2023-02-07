namespace Reservations;

public class ReservationId : TypedId
{
    public int Value { get; set; }
}

public class Reservation : IEntity
{
    public ReservationId ReservationId { get; }
    public CustomerId CustomerId { get; }

    private readonly Period _reservedPeriod;
    private ReservationStatus _status;

    public void Confirm()
    {
        _status = ReservationStatus.Confirmed;
    }
    
    public void Cancel()
    {
        _status = ReservationStatus.Canceled;
    }
    
    public void MarkAsNoShow()
    {
        _status = ReservationStatus.NoShow;
    }
    
    public bool IsAtDay(Period period)
    {
        return _reservedPeriod.SameDay(period);
    }

    public bool IsOverlappingWith(Period period)
    {
        return _status == ReservationStatus.Confirmed && _reservedPeriod.Overlaps(period);
    }

    internal static Reservation CreateNew(Customer customer, Period reservedPeriod) => 
        new(customer, reservedPeriod);

    private Reservation(Customer customer, Period reservedPeriod)
    {
        CustomerId = customer.CustomerId;
        _reservedPeriod = reservedPeriod;
        _status = ReservationStatus.Created;
    }
}