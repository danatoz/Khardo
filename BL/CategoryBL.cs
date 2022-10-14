using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Entities;

namespace BL
{
	public class CategoryBl
	{
		public async Task<Guid> AddOrUpdateAsync(Category entity)
		{
			entity.Id = await new CategoryDal().AddOrUpdateAsync(entity);
			return entity.Id;
		}

		public Task<bool> ExistsAsync(Guid id)
		{
			return new CategoryDal().ExistsAsync(id);
		}

		public async Task<Category> GetAsync(Guid id)
		{
			return await new CategoryDal().GetAsync(id);
		}

		public async Task<List<Category>> GetAsync()
		{
			return await new CategoryDal().GetAsync();
		}

		public async Task<List<Category>> GetAsync(Expression<Func<Category, bool>> predicate)
		{
			return await new CategoryDal().GetAsync(predicate);
		}

		public async Task<List<Category>> GetAsync(Expression<Func<Category, bool>> filter = null, Func<IQueryable<Category>, IOrderedQueryable<Category>> orderBy = null, params Expression<Func<Category, object>>[] includes)
		{
			return await new CategoryDal().GetAsync(filter, orderBy, includes);
		}

		public Task<bool> DeleteHardAsync(Guid id)
		{
			return new CategoryDal().DeleteHardAsync(id);
		}
	}
}
