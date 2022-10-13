using DAL;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
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

		public async Task<City> GetAsync(Guid id)
		{
			return await new CityDal().GetAsync(id);
		}

		public async Task<List<City>> GetAsync()
		{
			return await new CityDal().GetAsync();
		}

		public async Task<List<City>> GetAsync(Expression<Func<City, bool>> predicate)
		{
			return await new CityDal().GetAsync(predicate);
		}

		public Task<bool> DeleteHardAsync(Guid id)
		{
			return new CityDal().DeleteHardAsync(id);
		}
	}
}
