using System;
using System.Collections.Generic;
using System.Linq;
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

		public Task<Category> GetAsync(Guid id)
		{
			return new CategoryDal().GetAsync(id);
		}

		public Task<bool> DeleteHardAsync(Guid id)
		{
			return new CategoryDal().DeleteHardAsync(id);
		}

	}
}
