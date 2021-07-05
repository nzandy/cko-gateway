using System;

namespace Checkout.PaymentGateway.DataAccess.Entities
{
	public abstract class Entity
	{
		public Guid Id { get; set; }

		protected Entity()
		{
			Id = Guid.NewGuid();
		}
	}
}
