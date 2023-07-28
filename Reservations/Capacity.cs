using Reservations.Exceptions;

namespace Reservations;

public class Capacity : IValueObject
{
    public int Value { get; }

    public Capacity(int value)
    {
        if (value <= 0)
        {
            throw new InvalidResourceCapacityException();
        }

        Value = value;
    }
}