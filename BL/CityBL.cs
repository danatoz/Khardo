using DAL;
using Entities;
using System;
using System.Threading.Tasks;

namespace BL
{
	public class CityBL
	{
		public async Task<Guid> AddOrUpdateAsync(City entity)
		{
			entity.Id = await new CityDal().AddOrUpdateAsync(entity);
			return entity.Id;
		}

		public Task<bool> ExistsAsync(Guid id)
		{
			return new CityDal().ExistsAsync(id);
		}

		public Task<City> GetAsync(Guid id)
		{
			return new CityDal().GetAsync(id);
		}

		public Task<bool> DeleteHardAsync(Guid id)
		{
			return new CityDal().DeleteHardAsync(id);
		}
	}
}
