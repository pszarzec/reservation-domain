using System.Text;
using Reservations.Specifications;

namespace Reservations.Exceptions;

public class ReservationEnquiryRejectedException : DomainException
{
    internal ReservationEnquiryRejectedException(IEnumerable<SpecificationResult> rejections) 
        : base(CombineRejectionReasons(rejections))
    {
    }

    private static string CombineRejectionReasons(IEnumerable<SpecificationResult> rejections)
    {
        var expMessage = new StringBuilder();
        expMessage.Append("Reservation was rejected because:");

        foreach (var rejection in rejections.Where(x => x.Rejected))
        {
            expMessage.Append($" {rejection.RejectionReason}, ");
        }
        
        return expMessage.ToString();
    }
}