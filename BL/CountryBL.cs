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
	public class CountryBL
	{
		public async Task<Guid> AddOrUpdateAsync(Country entity)
		{
			entity.Id = await new CountryDal().AddOrUpdateAsync(entity);
			return entity.Id;
		}

		public Task<bool> ExistsAsync(Guid id)
		{
			return new CountryDal().ExistsAsync(id);
		}

		public async Task<Country> GetAsync(Guid id)
		{
			return await new CountryDal().GetAsync(id);
		}

		public async Task<List<Country>> GetAsync()
		{
			return await new CountryDal().GetAsync();
		}

		public async Task<List<Country>> GetAsync(Expression<Func<Country, bool>> predicate)
		{
			return await new CountryDal().GetAsync(predicate);
		}

		public Task<bool> DeleteHardAsync(Guid id)
		{
			return new CountryDal().DeleteHardAsync(id);
		}
	}
}
