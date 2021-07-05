using System;
using System.Threading.Tasks;
using Checkout.AcquiringBank.Services;
using Checkout.PaymentGateway.DataAccess;
using Checkout.PaymentGateway.Domain;
using Checkout.PaymentGateway.Models.Requests;
using Checkout.PaymentGateway.Models.Responses;
using Checkout.PaymentGateway.Services.Extensions;
using Checkout.Shared.Models;

namespace Checkout.PaymentGateway.Services
{
	public class PaymentService : IPaymentService
	{
		private readonly IGenericRepository<CardDetails> _cardDetailsRepo;
		private readonly IGenericRepository<Payment> _paymentRepo;
		private readonly IAcquiringBankService _acquiringBankService;

		public PaymentService(IGenericRepository<CardDetails> cardDetailsRepo, IGenericRepository<Payment> paymentRepo, IAcquiringBankService acquiringBankService)
		{
			_cardDetailsRepo = cardDetailsRepo;
			_paymentRepo = paymentRepo;
			_acquiringBankService = acquiringBankService;
		}

		public async Task<SubmitPaymentResponseDto> AttemptPaymentAsync(SubmitPaymentRequestDto paymentRequest)
		{
			// Convert to domain objects/entities and save to DB.
			var cardDetails = paymentRequest.ToCardDetailsDomainObject();
			var payment = paymentRequest.ToPaymentDomainObject();
			payment.CardDetailsId = cardDetails.Id;
			await SavePaymentEntities(cardDetails, payment);

			// Send to Acquiring Bank for processing.
			var result = await SendPaymentRequestToAcquringBankAndUpdateEntity(paymentRequest, payment);

			// Prepare response.
			var response = new SubmitPaymentResponseDto
			{
				PaymentResult = result
			};
			return response;
		}

		public async Task<GetPaymentResponseDto> GetPaymentAsync(Guid paymentId)
		{
			var payment = await _paymentRepo.GetByIdAsync(paymentId);

			if (payment == null)
			{
				return null;
			}
			var cardDetails = await _cardDetailsRepo.GetByIdAsync(payment.CardDetailsId);

			var response = ConvertToResponseDto(payment, cardDetails);
			return response;
		}

		private static GetPaymentResponseDto ConvertToResponseDto(Payment payment, CardDetails cardDetails)
		{
			return new GetPaymentResponseDto
			{
				Id = payment.Id,
				Result = payment.Result,
				Amount = payment.Amount,
				Currency = payment.Currency,
				MerchantId = payment.MerchantId,
				MaskedCardNumber = cardDetails.MaskedCardNumber,
				ExpiryMonth = cardDetails.ExpiryMonth,
				ExpiryYear = cardDetails.ExpiryYear
			};
		}

		private async Task<PaymentResult> SendPaymentRequestToAcquringBankAndUpdateEntity(SubmitPaymentRequestDto paymentRequest, Payment payment)
		{
			// Send request to Acquiring Bank and update Payment in DB with result.
			var result = await _acquiringBankService.ProcessPaymentAsync(paymentRequest);
			payment.Result = result;
			await _paymentRepo.UpdateAsync(payment);

			return result;
		}

		private async Task SavePaymentEntities(CardDetails cardDetails, Payment payment)
		{
			await _paymentRepo.InsertAsync(payment);

			// Note- would never, ever consider saving plaintext CC details.
			// In real world we would use some strong encryption/salting.
			await _cardDetailsRepo.InsertAsync(cardDetails);
		}
	}
}
