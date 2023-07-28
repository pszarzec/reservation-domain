using Common.Extensions;
using Reservations.Exceptions;

namespace Reservations;

public class Period : IValueObject
{
    public DateOnly Date { get; }
    public TimeOnly StartsAt { get; }
    public TimeOnly EndsAt { get; }

    public Period(DateOnly date, TimeOnly startsAt, TimeOnly endsAt)
    {
        if (date < DateOnly.FromDateTime(DateTime.Today))
        {
            throw new ReservationCannotStartInPastException();
        }

        if (startsAt > endsAt)
        {
            throw new ReservationCannotStartsAfterEndException();
        }
        
        if (endsAt < startsAt)
        {
            throw new ReservationCannotEndsBeforeStartException();
        }
        
        Date = date;
        StartsAt = startsAt;
        EndsAt = endsAt;
    }

    public bool SameDay(Period other) => Date == other.Date;

    public bool Overlaps(Period other)
    {
        if (Date != other.Date)
        {
            return false;
        }

        if (StartsAt == other.StartsAt || EndsAt == other.EndsAt)
        {
            return true;
        }

        var starts = StartsAt.IsBetweenInclusiveRange(other.StartsAt, other.EndsAt);
        var ends = EndsAt.IsBetweenInclusiveRange(other.StartsAt, other.EndsAt);

        return starts || ends;
    }
}