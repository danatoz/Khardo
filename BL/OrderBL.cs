using DAL;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
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

		public Task<Order> GetAsync(Guid id)
		{
			return new OrderDal().GetAsync(id);
		}

		public Task<bool> DeleteHardAsync(Guid id)
		{
			return new OrderDal().DeleteHardAsync(id);
		}
	}
}
