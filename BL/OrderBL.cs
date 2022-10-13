using DAL;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
	public class OrderBL
	{
		public async Task<Guid> AddOrUpdateAsync(Order entity)
		{
			entity.Id = await new OrderDal().AddOrUpdateAsync(entity);
			return entity.Id;
		}

		public Task<bool> ExistsAsync(Guid id)
		{
			return new OrderDal().ExistsAsync(id);
		}

		public async Task<Order> GetAsync(Guid id)
		{
			return await new OrderDal().GetAsync(id);
		}

		public async Task<List<Order>> GetAsync()
		{
			return await new OrderDal().GetAsync();
		}

		public async Task<List<Order>> GetAsync(Expression<Func<Order, bool>> predicate)
		{
			return await new OrderDal().GetAsync(predicate);
		}

		public Task<bool> DeleteHardAsync(Guid id)
		{
			return new OrderDal().DeleteHardAsync(id);
		}
	}
}
