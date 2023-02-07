namespace Reservations.Tests;

public class PeriodTests
{
    [Fact]
    public void Periods_in_the_same_day_not_overlapping()
    {
        var todayDate = DateOnly.FromDateTime(DateTime.Today);
        var morningPeriod = BuildPeriod(todayDate, 10, 11);
        var eveningPeriod = BuildPeriod(todayDate, 11, 12);

        var overlapped = morningPeriod.Overlaps(eveningPeriod);
        
        Assert.False(overlapped);
    }

    [Fact]
    public void Periods_in_other_days_not_overlapping()
    {
        var todayDate = DateOnly.FromDateTime(DateTime.Today);
        var tomorrowDate = DateOnly.FromDateTime(DateTime.Today).AddDays(1);
        var todayPeriod = BuildPeriod(todayDate, 8, 10);
        var tomorrowPeriod = BuildPeriod(tomorrowDate, 8, 10);

        var overlapped = todayPeriod.Overlaps(tomorrowPeriod);
        
        Assert.False(overlapped);
    }
    
    [Theory]
    [InlineData(10, 11, 10, 11)]
    [InlineData(10, 11, 10, 12)]
    [InlineData(10, 11, 8, 11)]
    [InlineData(10, 12, 8, 11)]
    public void Periods_overlappy(int periodStartsAt, int periodEndsAt, int overlappingStartsAt, int overlappingEndsAt)
    {
        var todayDate = DateOnly.FromDateTime(DateTime.Today);
        var period = BuildPeriod(todayDate, periodStartsAt, periodEndsAt);
        var overlappingPeriod = BuildPeriod(todayDate, overlappingStartsAt, overlappingEndsAt);

        var overlapped = period.Overlaps(overlappingPeriod);
        
        Assert.True(overlapped);
    }

    private Period BuildPeriod(DateOnly date, int startsAtHour, int endsAtHour) =>
        new(
            date, 
            TimeOnly.FromTimeSpan(TimeSpan.FromHours(startsAtHour)),
            TimeOnly.FromTimeSpan(TimeSpan.FromHours(endsAtHour)));
}