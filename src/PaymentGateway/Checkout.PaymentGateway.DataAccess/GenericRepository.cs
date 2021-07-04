using System;
using System.Collections.Generic;
using Checkout.PaymentGateway.Domain;

namespace Checkout.PaymentGateway.DataAccess
{
	public class GenericRepository<T> : IGenericRepository<T> where T : Entity
	{
		//TODO: Make threadsafe.
		private readonly Dictionary<Guid,T> _entities;

		public GenericRepository()
		{
			_entities = new Dictionary<Guid, T>();
		}

		public T GetById(Guid id)
		{
			return _entities[id];
		}

		public void Insert(T entity)
		{
			_entities.Add(entity.Id, entity);
		}
	}
}
