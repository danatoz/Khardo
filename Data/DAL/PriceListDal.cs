using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
	public class PriceListDal : BaseDal<AppDbContext, PriceList, Guid>
	{
		public PriceListDal()
		{

		}

		public PriceListDal(AppDbContext context) : base(context)
		{

		}

		protected override Expression<Func<PriceList, Guid>> GetIdByDbObjectExpression()
		{
			return item => item.Id;
		}
	}
}
