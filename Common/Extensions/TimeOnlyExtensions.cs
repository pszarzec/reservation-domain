namespace Common.Extensions;

public static class TimeOnlyExtensions
{
    public static bool IsBetweenInclusiveRange(this TimeOnly time, TimeOnly start, TimeOnly end)
    {
        long startTicks = start.Ticks;
        long endTicks = end.Ticks;

        return startTicks <= endTicks
            ? (startTicks < time.Ticks && endTicks > time.Ticks)
            : (startTicks < time.Ticks || endTicks > time.Ticks);
    }
}