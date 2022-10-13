using DAL;
using Entities;
using System;
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

		public Task<News> GetAsync(Guid id)
		{
			return new NewsDal().GetAsync(id);
		}

		public Task<bool> DeleteHardAsync(Guid id)
		{
			return new NewsDal().DeleteHardAsync(id);
		}
	}
}
