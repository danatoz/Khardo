using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace DAL
{
	public class CategoryDal : BaseDal<ApplicationDbContext, Category, int>
	{
		public CategoryDal()
		{
			
		}
		public CategoryDal(ApplicationDbContext context) : base(context)
		{
			
		}

		protected override Expression<Func<Category, int>> GetIdByDbObjectExpression()
		{
			return item => item.Id;
		}
	}
}
