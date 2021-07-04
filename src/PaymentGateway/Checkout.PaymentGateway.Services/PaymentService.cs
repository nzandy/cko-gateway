using System;
using Checkout.PaymentGateway.DataAccess;
using Checkout.PaymentGateway.Domain;
using Checkout.PaymentGateway.Models;
using Checkout.PaymentGateway.Services.Extensions;

namespace Checkout.PaymentGateway.Services
{
	public class PaymentService : IPaymentService
	{
		private IGenericRepository<CardDetails> _cardDetailsRepo;
		private IGenericRepository<Payment> _paymentRepo;
		public bool AttemptPayment(PaymentDto paymentRequest)
		{
			var cardDetails = paymentRequest.ToCardDetailsDomainObject();
			var payment = paymentRequest.ToPaymentDomainObject();
			payment.CardDetailsId = cardDetails.Id;

			return false;
		}

		private void SavePaymentEntities(CardDetails cardDetails, Payment payment)
		{
			_paymentRepo.Insert(payment);
			_cardDetailsRepo.Insert(cardDetails);

		}
	}
}
