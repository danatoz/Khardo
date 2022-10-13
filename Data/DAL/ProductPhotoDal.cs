using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
	public class ProductPhotoDal : BaseDal<AppDbContext, ProductPhoto, Guid>
	{
		public ProductPhotoDal()
		{

		}

		public ProductPhotoDal(AppDbContext context) : base(context)
		{

		}

		protected override Expression<Func<ProductPhoto, Guid>> GetIdByDbObjectExpression()
		{
			return item => item.Id;
		}
	}
}
