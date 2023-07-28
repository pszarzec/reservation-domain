namespace Reservations.Specifications.Restaurants;

internal class CapacitySpecification : ISpecification
{
    public SpecificationResult IsSatisfied(ReservationEnquiry enquiry, ResourceProperties resourceProperties)
    {
        if (resourceProperties.Capacity.Value < enquiry.Capacity.Value)
        {
            return new SpecificationResult(true, "Resource capacity is to small to hold requested capacity.");
        }

        return new SpecificationResult(false);
    }
}