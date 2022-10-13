using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace DAL
{
	public class ManufacturerDal : BaseDal<AppDbContext, Manufacturer, Guid>
	{
		public ManufacturerDal()
		{
			
		}

		public ManufacturerDal(AppDbContext context) : base(context)
		{
			
		}

		protected override Expression<Func<Manufacturer, Guid>> GetIdByDbObjectExpression()
		{
			return item => item.Id;
		}
	}
}
