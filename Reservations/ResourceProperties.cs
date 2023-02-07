namespace Reservations;

internal class ResourceProperties
{
    public Capacity Capacity { get; }

    public ResourceProperties(Capacity capacity)
    {
        Capacity = capacity;
    }
}