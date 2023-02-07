namespace Reservations;

public class CustomerId : TypedId
{
    public int Value { get; set; }
}

/// <summary>
/// Customer aggregate is need because this invariant exists:
/// "A customer can only have one reservation at the same time."
/// </summary>
public class Customer : IAggregateRoot, IEntity
{
    public CustomerId CustomerId { get; }

    private readonly string _name;
    private readonly List<Reservation> _reservations;

    public static Customer CreateNew(string name, List<Reservation> reservations) => 
        new(name, reservations);

    private Customer(string name, List<Reservation> reservations)
    {
        _reservations = reservations;
        _name = name;
    }
}