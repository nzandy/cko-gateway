using Checkout.PaymentGateway.Domain;
using System;

namespace Checkout.PaymentGateway.DataAccess
{
	public interface IPaymentRepository
	{
		public Guid SavePayment(Payment payment);
		public Payment GetPayment(Guid id);
	}
}
