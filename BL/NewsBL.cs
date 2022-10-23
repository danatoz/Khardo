using DAL;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BL
{
	public class NewsBL
	{
		public async Task<Guid> AddOrUpdateAsync(News entity)
		{
			entity.Id = await new NewsDal().AddOrUpdateAsync(entity);
			return entity.Id;
		}

		public Task<bool> ExistsAsync(Guid id)
		{
			return new NewsDal().ExistsAsync(id);
		}

		public async Task<News> GetAsync(Guid id)
		{
			return await new NewsDal().GetAsync(id);
		}

		public async Task<List<News>> GetAsync()
		{
			return await new NewsDal().GetAsync();
		}

		public async Task<List<News>> GetAsync(Expression<Func<News, bool>> predicate)
		{
			return await new NewsDal().GetAsync(predicate);
		}

		public async Task<List<News>> GetAsync(Expression<Func<News, bool>> filter = null, params Expression<Func<News, object>>[] includes)
		{
			return await new NewsDal().GetAsync(filter, includes);
		}

		public async Task<List<News>> GetAsync(Expression<Func<News, bool>> filter = null, Func<IQueryable<News>, IOrderedQueryable<News>> orderBy = null, params Expression<Func<News, object>>[] includes)
		{
			return await new NewsDal().GetAsync(filter, orderBy, includes);
		}

		public Task<bool> DeleteHardAsync(Guid id)
		{
			return new NewsDal().DeleteHardAsync(id);
		}
	}
}
