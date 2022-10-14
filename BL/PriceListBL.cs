using DAL;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BL
{
	public class PriceListBL
	{
		public async Task<Guid> AddOrUpdateAsync(PriceList entity)
		{
			entity.Id = await new PriceListDal().AddOrUpdateAsync(entity);
			return entity.Id;
		}

		public Task<bool> ExistsAsync(Guid id)
		{
			return new PriceListDal().ExistsAsync(id);
		}

		public async Task<PriceList> GetAsync(Guid id)
		{
			return await new PriceListDal().GetAsync(id);
		}

		public async Task<List<PriceList>> GetAsync()
		{
			return await new PriceListDal().GetAsync();
		}

		public async Task<List<PriceList>> GetAsync(Expression<Func<PriceList, bool>> predicate)
		{
			return await new PriceListDal().GetAsync(predicate);
		}

		public async Task<List<PriceList>> GetAsync(Expression<Func<PriceList, bool>> filter = null, Func<IQueryable<PriceList>, IOrderedQueryable<PriceList>> orderBy = null, params Expression<Func<PriceList, object>>[] includes)
		{
			return await new PriceListDal().GetAsync(filter, orderBy, includes);
		}

		public Task<bool> DeleteHardAsync(Guid id)
		{
			return new PriceListDal().DeleteHardAsync(id);
		}
	}
}
