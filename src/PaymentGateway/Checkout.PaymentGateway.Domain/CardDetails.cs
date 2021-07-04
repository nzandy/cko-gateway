using System;

namespace Checkout.PaymentGateway.Domain
{
	public class CardDetails : Entity
	{
		public string CardNumber { get; set; }
		public string ExpiryYear { get; set; }
		public string ExpiryMonth { get; set; }
	}
}
