using Entities;
using System.Linq.Expressions;


namespace DAL
{
	public class ProductTemplateDal : BaseDal<AppDbContext, ProductTemplate, Guid>
	{
		public ProductTemplateDal()
		{
			
		}
		public ProductTemplateDal(AppDbContext context) : base(context)
		{
			
		}
		protected override Expression<Func<ProductTemplate, Guid>> GetIdByDbObjectExpression()
		{
			return item => item.Id;
		}
	}
}
