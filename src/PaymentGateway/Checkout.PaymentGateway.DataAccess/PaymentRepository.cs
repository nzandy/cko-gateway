using System;
using Checkout.PaymentGateway.Domain;

namespace Checkout.PaymentGateway.DataAccess
{
	public class PaymentRepository : IPaymentRepository
	{
		public Guid SavePayment(Payment payment)
		{
			throw new NotImplementedException();
		}

		public Payment GetPayment(Guid id)
		{
			throw new NotImplementedException();
		}
	}
}
