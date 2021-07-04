using System;
using Checkout.PaymentGateway.Models;

namespace Checkout.PaymentGateway.Services
{
	public interface IPaymentService
	{
		//TODO: Make async
		public bool AttemptPayment(PaymentRequest paymentRequest);
	}
}
