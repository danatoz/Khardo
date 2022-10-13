using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
	public class OrderPositionDal : BaseDal<AppDbContext, OrderPosition, Guid>
	{
		public OrderPositionDal()
		{

		}

		public OrderPositionDal(AppDbContext context) : base(context)
		{

		}

		protected override Expression<Func<OrderPosition, Guid>> GetIdByDbObjectExpression()
		{
			return item => item.Id;
		}
	}
}
