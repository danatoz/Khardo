using System.Linq.Expressions;
using Entities;

namespace DAL
{
	public class CountryDal : BaseDal<AppDbContext, Country, Guid>
	{
		public CountryDal()
		{
			
		}

		public CountryDal(AppDbContext context) : base(context)
		{
			
		}

		protected override Expression<Func<Country, Guid>> GetIdByDbObjectExpression()
		{
			return item => item.Id;
		}
	}
}
