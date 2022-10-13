using DAL;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
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

		public Task<ProductPhoto> GetAsync(Guid id)
		{
			return new ProductPhotoDal().GetAsync(id);
		}

		public Task<bool> DeleteHardAsync(Guid id)
		{
			return new ProductPhotoDal().DeleteHardAsync(id);
		}
	}
}
