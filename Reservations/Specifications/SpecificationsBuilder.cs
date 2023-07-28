using Reservations.Specifications.Restaurants;

namespace Reservations.Specifications;

internal static class SpecificationsBuilder
{
    internal static IReadOnlyCollection<ISpecification> BuildRequired()
    {
        return new List<ISpecification>
        {
            new CapacitySpecification()
        };
    }
}