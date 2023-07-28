namespace Reservations.Exceptions;

public class InvalidResourceCapacityException : DomainException
{
    internal InvalidResourceCapacityException() : base("Invalid resource capacity must be greater than zero.")
    {
    }
}