using DAL;
using Entities;
using System;
using System.Threading.Tasks;

namespace BL
{
	public class PriceListBL
	{
		public async Task<Guid> AddOrUpdateAsync(PriceList entity)
		{
			entity.Id = await new PriceListDal().AddOrUpdateAsync(entity);
			return entity.Id;
		}

		public Task<bool> ExistsAsync(Guid id)
		{
			return new PriceListDal().ExistsAsync(id);
		}

		public Task<PriceList> GetAsync(Guid id)
		{
			return new PriceListDal().GetAsync(id);
		}

		public Task<bool> DeleteHardAsync(Guid id)
		{
			return new PriceListDal().DeleteHardAsync(id);
		}
	}
}
