using Checkout.PaymentGateway.DataAccess.Entities;
using Checkout.PaymentGateway.Models.Requests;

namespace Checkout.PaymentGateway.Services.Extensions
{
	public static class PaymentDtoExtensions
	{
		public static CardDetails ToCardDetailsEntity(this SubmitPaymentRequestDto dto)
		{
			return new CardDetails
			{
				CardNumber = dto.CardDetails.CardNumber,
				ExpiryMonth = dto.CardDetails.ExpiryMonth,
				ExpiryYear = dto.CardDetails.ExpiryYear,
				MerchantId = dto.MerchantId
			};
		}

		public static Payment ToPaymentEntity(this SubmitPaymentRequestDto dto)
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
