using Common;

namespace Reservations.Exceptions;

public class ReservationCannotStartInPastException : DomainException
{
    internal ReservationCannotStartInPastException() : base("Reservation date cannot be in the past.")
    {
    }
}