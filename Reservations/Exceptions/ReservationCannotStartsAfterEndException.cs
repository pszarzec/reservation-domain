namespace Reservations.Exceptions;

public class ReservationCannotStartsAfterEndException : DomainException
{
    internal ReservationCannotStartsAfterEndException() 
        : base("The defined time interval has a start time specified after the end time.")
    {
    }
}