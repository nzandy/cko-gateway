using System;
using Checkout.PaymentGateway.Domain;

namespace Checkout.PaymentGateway.DataAccess
{
	public interface IGenericRepository<T> where T : Entity
	{
		T GetById(Guid id);
		void Insert(T obj);
	}
}