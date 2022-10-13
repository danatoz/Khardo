using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace DAL
{
	public class OrderDal : BaseDal<AppDbContext, Order, Guid>
	{
		public OrderDal()
		{
			
		}

		public OrderDal(AppDbContext context) : base(context)
		{
			
		}

		protected override Expression<Func<Order, Guid>> GetIdByDbObjectExpression()
		{
			return item => item.Id;
		}
	}
}
