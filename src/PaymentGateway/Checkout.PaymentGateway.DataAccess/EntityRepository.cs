using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Checkout.PaymentGateway.DataAccess.Entities;

namespace Checkout.PaymentGateway.DataAccess
{
	/// <summary>
	/// For the sake of time I have gone with an in-memory repo, in the real world we would implement the interface
	/// with EF, dapper, or similar.
	/// I have decided to add some async behaviour / delays to mimic a real DB.
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public class EntityRepository<T> : IEntityRepository<T> where T : Entity
	{
		// Not threadsafe. I would have used ConcurrentDictionary but the update functionality
		// was going to add too much complexity for my given implementation timespan.
		private readonly Dictionary<Guid,T> _entities;

		public EntityRepository()
		{
			_entities = new Dictionary<Guid, T>();
		}

		public async Task<T> GetByIdAsync(Guid id)
		{
			await Task.Delay(200);
			return _entities.TryGetValue(id, out var value) ? value : null;
		}

		public async Task InsertAsync(T entity)
		{
			await Task.Delay(200);
			_entities.Add(entity.Id, entity);
		}

		public async Task UpdateAsync(T entity)
		{
			await Task.Delay(200);
			_entities[entity.Id] = entity;
		}
	}
}
