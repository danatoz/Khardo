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
	public class ManufacturerBL
	{
		public async Task<Guid> AddOrUpdateAsync(Manufacturer entity)
		{
			entity.Id = await new ManufacturerDal().AddOrUpdateAsync(entity);
			return entity.Id;
		}

		public Task<bool> ExistsAsync(Guid id)
		{
			return new ManufacturerDal().ExistsAsync(id);
		}

		public async Task<Manufacturer> GetAsync(Guid id)
		{
			return await new ManufacturerDal().GetAsync(id);
		}

		public async Task<List<Manufacturer>> GetAsync()
		{
			return await new ManufacturerDal().GetAsync();
		}

		public async Task<List<Manufacturer>> GetAsync(Expression<Func<Manufacturer, bool>> predicate)
		{
			return await new ManufacturerDal().GetAsync(predicate);
		}

		public async Task<List<Manufacturer>> GetAsync(Expression<Func<Manufacturer, bool>> filter = null, params Expression<Func<Manufacturer, object>>[] includes)
		{
			return await new ManufacturerDal().GetAsync(filter, includes);
		}

		public async Task<List<Manufacturer>> GetAsync(Expression<Func<Manufacturer, bool>> filter = null, Func<IQueryable<Manufacturer>, IOrderedQueryable<Manufacturer>> orderBy = null, params Expression<Func<Manufacturer, object>>[] includes)
		{
			return await new ManufacturerDal().GetAsync(filter, orderBy, includes);
		}

		public Task<bool> DeleteHardAsync(Guid id)
		{
			return new ManufacturerDal().DeleteHardAsync(id);
		}
	}
}
