namespace Reservations.Specifications;

public record SpecificationResult(bool Rejected, string RejectionReason = "");

internal interface ISpecification
{
    SpecificationResult IsSatisfied(ReservationEnquiry enquiry, ResourceProperties resourceProperties);
}