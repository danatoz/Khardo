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
		public async Task<int> AddOrUpdateAsync(Category entity)
		{
			entity.Id = await new CategoryDal().AddOrUpdateAsync(entity);
			return entity.Id;
		}

		public Task<bool> ExistsAsync(int id)
		{
			return new CategoryDal().ExistsAsync(id);
		}

		public Task<Category> GetAsync(int id)
		{
			return new CategoryDal().GetAsync(id);
		}

		public Task<bool> DeleteHardAsync(int id)
		{
			return new CategoryDal().DeleteHardAsync(id);
		}

	}
}
