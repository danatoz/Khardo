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
	public class OrderPositionBL
	{
		public async Task<Guid> AddOrUpdateAsync(OrderPosition entity)
		{
			entity.Id = await new OrderPositionDal().AddOrUpdateAsync(entity);
			return entity.Id;
		}

		public Task<bool> ExistsAsync(Guid id)
		{
			return new OrderPositionDal().ExistsAsync(id);
		}

		public async Task<OrderPosition> GetAsync(Guid id)
		{
			return await new OrderPositionDal().GetAsync(id);
		}

		public async Task<List<OrderPosition>> GetAsync()
		{
			return await new OrderPositionDal().GetAsync();
		}

		public async Task<List<OrderPosition>> GetAsync(Expression<Func<OrderPosition, bool>> predicate)
		{
			return await new OrderPositionDal().GetAsync(predicate);
		}

		public async Task<List<OrderPosition>> GetAsync(Expression<Func<OrderPosition, bool>> filter = null, params Expression<Func<OrderPosition, object>>[] includes)
		{
			return await new OrderPositionDal().GetAsync(filter, includes);
		}

		public async Task<List<OrderPosition>> GetAsync(Expression<Func<OrderPosition, bool>> filter = null, Func<IQueryable<OrderPosition>, IOrderedQueryable<OrderPosition>> orderBy = null, params Expression<Func<OrderPosition, object>>[] includes)
		{
			return await new OrderPositionDal().GetAsync(filter, orderBy, includes);
		}

		public Task<bool> DeleteHardAsync(Guid id)
		{
			return new OrderPositionDal().DeleteHardAsync(id);
		}
	}
}
