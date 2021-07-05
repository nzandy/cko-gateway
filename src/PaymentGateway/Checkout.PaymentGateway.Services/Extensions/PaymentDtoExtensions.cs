using Checkout.PaymentGateway.Domain;
using Checkout.PaymentGateway.Models;
using Checkout.PaymentGateway.Models.Requests;

namespace Checkout.PaymentGateway.Services.Extensions
{
	public static class PaymentDtoExtensions
	{
		public static CardDetails ToCardDetailsDomainObject(this SubmitPaymentRequestDto dto)
		{
			return new CardDetails
			{
				CardNumber = dto.CardDetails.CardNumber,
				ExpiryMonth = dto.CardDetails.ExpiryMonth,
				ExpiryYear = dto.CardDetails.ExpiryYear,
				MerchantId = dto.MerchantId
			};
		}

		public static Payment ToPaymentDomainObject(this SubmitPaymentRequestDto dto)
		{
			return new Payment
			{
				Currency = dto.Currency,
				Amount = dto.Amount,
				MerchantId = dto.MerchantId
			};
		}
	}
}
