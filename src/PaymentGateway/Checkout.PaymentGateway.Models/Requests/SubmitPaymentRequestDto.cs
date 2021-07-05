namespace Checkout.PaymentGateway.Models.Requests
{
	public class SubmitPaymentRequestDto
	{
		public int MerchantId { get; set; }
		public CardDetailsDto CardDetails { get; set; }
		public decimal Amount { get; set; }
		public string Currency { get; set; }
	}
}

