using Checkout.PaymentGateway.Domain;
using Checkout.PaymentGateway.Models;

namespace Checkout.PaymentGateway.Services.Extensions
{
	public static class PaymentDtoExtensions
	{
		public static CardDetails ToCardDetailsDomainObject(this PaymentDto dto)
		{
			return new CardDetails
			{
				CardNumber = dto.CardDetails.CardNumber,
				ExpiryMonth = dto.CardDetails.ExpiryMonth,
				ExpiryYear = dto.CardDetails.ExpiryYear,
				MerchantId = dto.MerchantId
			};
		}

		public static Payment ToPaymentDomainObject(this PaymentDto dto)
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
