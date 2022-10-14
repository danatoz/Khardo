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
	public class ProductTemplateBL
	{
		public async Task<Guid> AddOrUpdateAsync(ProductTemplate entity)
		{
			entity.Id = await new ProductTemplateDal().AddOrUpdateAsync(entity);
			return entity.Id;
		}

		public Task<bool> ExistsAsync(Guid id)
		{
			return new ProductTemplateDal().ExistsAsync(id);
		}

		public async Task<ProductTemplate> GetAsync(Guid id)
		{
			return await new ProductTemplateDal().GetAsync(id);
		}

		public async Task<List<ProductTemplate>> GetAsync()
		{
			return await new ProductTemplateDal().GetAsync();
		}

		public async Task<List<ProductTemplate>> GetAsync(Expression<Func<ProductTemplate, bool>> predicate)
		{
			return await new ProductTemplateDal().GetAsync(predicate);
		}

		public async Task<List<ProductTemplate>> GetAsync(Expression<Func<ProductTemplate, bool>> filter = null, Func<IQueryable<ProductTemplate>, IOrderedQueryable<ProductTemplate>> orderBy = null, params Expression<Func<ProductTemplate, object>>[] includes)
		{
			return await new ProductTemplateDal().GetAsync(filter, orderBy, includes);
		}

		public Task<bool> DeleteHardAsync(Guid id)
		{
			return new ProductTemplateDal().DeleteHardAsync(id);
		}
	}
}
