namespace Reservations;

public class ReservationEnquiry : IValueObject
{
    public Period Period { get; } 
    public Customer Customer { get; }
    public Capacity Capacity { get; }
    
    public ReservationEnquiry(Period period, Customer customer, Capacity capacity)
    {
        Period = period;
        Customer = customer;
        Capacity = capacity;
    }
}