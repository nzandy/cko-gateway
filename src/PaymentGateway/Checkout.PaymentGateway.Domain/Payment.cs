using System;

namespace Checkout.PaymentGateway.Domain
{
	public class Payment : Entity
	{
		public Guid CardDetailsId { get; set; }
		public decimal Amount { get; set; }
		public string Currency { get; set; }
	}
}
