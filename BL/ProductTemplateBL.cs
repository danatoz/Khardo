using System;
using System.Collections.Generic;
using System.Linq;
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

		public Task<ProductTemplate> GetAsync(Guid id)
		{
			return new ProductTemplateDal().GetAsync(id);
		}

		public Task<bool> DeleteHardAsync(Guid id)
		{
			return new ProductTemplateDal().DeleteHardAsync(id);
		}
	}
}
