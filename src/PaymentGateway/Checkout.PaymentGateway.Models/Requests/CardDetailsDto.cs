using System.ComponentModel.DataAnnotations;
using Checkout.PaymentGateway.Models.Validators;

namespace Checkout.PaymentGateway.Models.Requests
{
	public class CardDetailsDto
	{
		[Required]
		[CreditCard]
		public string CardNumber { get; set; }

		[YearIsCurrentOrFuture]
		public int ExpiryYear { get; set; }

		[Range(1, 12)]
		public int ExpiryMonth { get; set; }
	}
}
