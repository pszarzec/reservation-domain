namespace Reservations.Exceptions;

public class ResourceIsAlreadyReserved : DomainException
{
    internal ResourceIsAlreadyReserved() 
        : base("Cannot make reservation because this resource is already reserved.")
    {
    }
}