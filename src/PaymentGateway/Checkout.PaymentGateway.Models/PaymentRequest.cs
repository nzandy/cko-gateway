namespace Checkout.PaymentGateway.Models
{
	public class PaymentRequest
	{
		public CardDetails CardDetails { get; set; }
		public decimal Amount { get; set; }
		public string Currency { get; set; }
	}
}

