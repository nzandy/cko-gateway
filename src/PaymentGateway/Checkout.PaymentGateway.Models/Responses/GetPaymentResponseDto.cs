using System;
using Checkout.Shared.Models;

namespace Checkout.PaymentGateway.Models.Responses
{
	public class GetPaymentResponseDto
	{
		public Guid Id { get; set; }
		public PaymentResult Result { get; set; }
		public decimal Amount { get; set; }
		public string Currency { get; set; }
		public int MerchantId { get; set; }
		public string MaskedCardNumber { get; set; }
		public string ExpiryYear { get; set; }
		public string ExpiryMonth { get; set; }
	}
}
