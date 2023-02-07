namespace Reservations.Exceptions;

public class ReservationCannotEndsBeforeStartException : DomainException
{
    internal ReservationCannotEndsBeforeStartException() 
        : base("The defined time interval has a end time specified before the start time.")
    {
    }
}