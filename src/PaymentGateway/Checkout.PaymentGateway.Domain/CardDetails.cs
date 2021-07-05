using System;
using System.Text.RegularExpressions;

namespace Checkout.PaymentGateway.Domain
{
	public class CardDetails : MerchantEntity
	{
		public string CardNumber { get; set; }
		public string ExpiryYear { get; set; }
		public string ExpiryMonth { get; set; }

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
