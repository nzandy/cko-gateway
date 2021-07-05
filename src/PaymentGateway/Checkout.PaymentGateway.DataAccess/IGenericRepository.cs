﻿using System;
using System.Threading.Tasks;
using Checkout.PaymentGateway.Domain;

namespace Checkout.PaymentGateway.DataAccess
{
	public interface IGenericRepository<T> where T : Entity
	{
		Task<T> GetByIdAsync(Guid id);
		Task InsertAsync(T obj);
		Task UpdateAsync(T obj);
	}
}