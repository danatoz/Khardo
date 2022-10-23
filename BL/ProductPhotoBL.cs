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
	public class ProductPhotoBL
	{
		public async Task<Guid> AddOrUpdateAsync(ProductPhoto entity)
		{
			entity.Id = await new ProductPhotoDal().AddOrUpdateAsync(entity);
			return entity.Id;
		}

		public Task<bool> ExistsAsync(Guid id)
		{
			return new ProductPhotoDal().ExistsAsync(id);
		}

		public async Task<ProductPhoto> GetAsync(Guid id)
		{
			return await new ProductPhotoDal().GetAsync(id);
		}

		public async Task<List<ProductPhoto>> GetAsync()
		{
			return await new ProductPhotoDal().GetAsync();
		}

		public async Task<List<ProductPhoto>> GetAsync(Expression<Func<ProductPhoto, bool>> predicate)
		{
			return await new ProductPhotoDal().GetAsync(predicate);
		}

		public async Task<List<ProductPhoto>> GetAsync(Expression<Func<ProductPhoto, bool>> filter = null, params Expression<Func<ProductPhoto, object>>[] includes)
		{
			return await new ProductPhotoDal().GetAsync(filter, includes);
		}

		public async Task<List<ProductPhoto>> GetAsync(Expression<Func<ProductPhoto, bool>> filter = null, Func<IQueryable<ProductPhoto>, IOrderedQueryable<ProductPhoto>> orderBy = null, params Expression<Func<ProductPhoto, object>>[] includes)
		{
			return await new ProductPhotoDal().GetAsync(filter, orderBy, includes);
		}

		public Task<bool> DeleteHardAsync(Guid id)
		{
			return new ProductPhotoDal().DeleteHardAsync(id);
		}
	}
}
