using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
	public class ProductDal : BaseDal<AppDbContext, Product, Guid>
	{
		public ProductDal()
		{

		}

		public ProductDal(AppDbContext context) : base(context)
		{

		}

		protected override Expression<Func<Product, Guid>> GetIdByDbObjectExpression()
		{
			return item => item.Id;
		}
	}
}
