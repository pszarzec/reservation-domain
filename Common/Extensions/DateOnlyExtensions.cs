namespace Common.Extensions;

public static class DateOnlyExtensions
{
    public static DateOnly Today(this DateOnly dateOnly)
    {
        return DateOnly.FromDateTime(DateTime.Today);
    }
}