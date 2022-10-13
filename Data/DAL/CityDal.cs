using System.Linq.Expressions;
using Entities;

namespace DAL
{
    public class CityDal : BaseDal<AppDbContext, City, Guid>
    {
	    public CityDal()
	    {
		    
	    }

	    public CityDal(AppDbContext context) : base(context)
	    {
		    
	    }

	    protected override Expression<Func<City, Guid>> GetIdByDbObjectExpression()
	    {
		    return item => item.Id;
	    }
    }
}
