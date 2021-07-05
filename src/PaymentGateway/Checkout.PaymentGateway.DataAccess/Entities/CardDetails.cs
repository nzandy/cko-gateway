namespace Checkout.PaymentGateway.DataAccess.Entities
{
	public class CardDetails : MerchantEntity
	{
		public string CardNumber { get; set; }
		public int ExpiryYear { get; set; }
		public int ExpiryMonth { get; set; }

		/// <summary>
		/// Copied from Stack overflow.
		/// This is domain logic rather than belonging on the entity, but for a quick POC I avoided adding
		/// domain layer as was already taking a lot of time!
		/// Note: Ran out of time to surround this with tests... sorry.
		/// </summary>
		public string MaskedCardNumber
		{
			get
			{
				var firstSixDigitsToRemainUnmasked = CardNumber.Substring(0, 6);
				var lastFourDigitsToRemainUnmasked = CardNumber.Substring(CardNumber.Length - 4, 4);

				var maskedMiddleDigits = new string('X', CardNumber.Length - firstSixDigitsToRemainUnmasked.Length - lastFourDigitsToRemainUnmasked.Length);

				var maskedString = string.Concat(firstSixDigitsToRemainUnmasked, maskedMiddleDigits, lastFourDigitsToRemainUnmasked);

				return maskedString;
			}
		}
	}
}
