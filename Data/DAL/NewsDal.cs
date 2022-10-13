using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace DAL
{
	public class NewsDal : BaseDal<AppDbContext, News, Guid>
	{
		public NewsDal()
		{
			
		}

		public NewsDal(AppDbContext context) : base(context)
		{
			
		}

		protected override Expression<Func<News, Guid>> GetIdByDbObjectExpression()
		{
			return item => item.Id;
		}
	}
}
