using System;
using System.Threading.Tasks;
using DAL;
using Entities;

namespace BL
{
    public class ProductBL
    {
	    private readonly AppDbContext _context;
	    public ProductBL(AppDbContext context)
	    {
		    _context = context;
	    }

	    public ProductBL()
	    {
		    
	    }
	    //public async Task<IEnumerable<Product>> GetSimpleByAliasAsync(string alias)
	    //{
		   // //return await _context.Products.Where(item => item.Alias == alias && item.Catalog != null).ToListAsync();
	    //}

	    //public async Task GetAsync(string alias)
	    //{

	    //}

	    public async Task<Guid> AddOrUpdateAsync(Product entity)
	    {
		    entity.Id = await new ProductDal().AddOrUpdateAsync(entity);
		    return entity.Id;
	    }

	    public Task<bool> ExistsAsync(Guid id)
	    {
		    return new ProductDal().ExistsAsync(id);
	    }

	    public Task<Product> GetAsync(Guid id)
	    {
		    return new ProductDal().GetAsync(id);
	    }

	    public Task<bool> DeleteHardAsync(Guid id)
	    {
		    return new ProductDal().DeleteHardAsync(id);
	    }
    }
}
