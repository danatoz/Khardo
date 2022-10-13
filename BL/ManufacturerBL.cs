using DAL;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
	public class ManufacturerBL
	{
		public async Task<Guid> AddOrUpdateAsync(Manufacturer entity)
		{
			entity.Id = await new ManufacturerDal().AddOrUpdateAsync(entity);
			return entity.Id;
		}

		public Task<bool> ExistsAsync(Guid id)
		{
			return new ManufacturerDal().ExistsAsync(id);
		}

		public Task<Manufacturer> GetAsync(Guid id)
		{
			return new ManufacturerDal().GetAsync(id);
		}

		public Task<bool> DeleteHardAsync(Guid id)
		{
			return new ManufacturerDal().DeleteHardAsync(id);
		}
	}
}
