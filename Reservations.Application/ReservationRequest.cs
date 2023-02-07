namespace Reservations.Application;

public class ReservationRequest
{
    public int CustomerId { get; }
    public int Capacity { get; }
    public DateTime DateAndTime { get; }
    public int ResourceId { get; }

    public ReservationRequest(int customerId, int capacity, DateTime dateAndTime, int resourceId)
    {
        CustomerId = customerId;
        Capacity = capacity;
        DateAndTime = dateAndTime;
        ResourceId = resourceId;
    }
}