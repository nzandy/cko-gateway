using System.ComponentModel.DataAnnotations;
using Checkout.PaymentGateway.Models.Validators;

namespace Checkout.PaymentGateway.Models.Requests
{
	public class SubmitPaymentRequestDto
	{
		public int MerchantId { get; set; }

		[Required]
		public CardDetailsDto CardDetails { get; set; }

		[Required]
		[Range(0, int.MaxValue, ErrorMessage = "Only positive amount allowed.")]
		public decimal Amount { get; set; }

		[Iso4217CurrencyCode]
		[Required]
		public string Currency { get; set; }
	}
}

