using DAL;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
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

		public Task<OrderPosition> GetAsync(Guid id)
		{
			return new OrderPositionDal().GetAsync(id);
		}

		public Task<bool> DeleteHardAsync(Guid id)
		{
			return new OrderPositionDal().DeleteHardAsync(id);
		}
	}
}
