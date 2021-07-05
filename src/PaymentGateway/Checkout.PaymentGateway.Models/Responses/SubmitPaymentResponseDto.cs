using System;
using Checkout.Shared.Models;

namespace Checkout.PaymentGateway.Models.Responses
{
	public class SubmitPaymentResponseDto
	{
		public PaymentResult PaymentResult { get; set; }
		public Guid PaymentId { get; set; }
	}
}
