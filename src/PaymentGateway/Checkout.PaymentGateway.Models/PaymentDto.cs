namespace Checkout.PaymentGateway.Models
{
	public class PaymentDto
	{
		public int MerchantId { get; set; }
		public CardDetailsDto CardDetails { get; set; }
		public decimal Amount { get; set; }
		public string Currency { get; set; }
	}
}

