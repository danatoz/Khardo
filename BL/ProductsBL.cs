using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Microsoft.EntityFrameworkCore;

namespace BL
{
    public class ProductsBL
    {
	    private readonly ApplicationDbContext _context;
	    public ProductsBL(ApplicationDbContext context)
	    {
		    _context = context;
	    }

	    public ProductsBL()
	    {
		    
	    }
	    //public async Task<IEnumerable<Product>> GetSimpleByAliasAsync(string alias)
	    //{
		   // //return await _context.Products.Where(item => item.Alias == alias && item.Catalog != null).ToListAsync();
	    //}

	    public async Task GetAsync(string alias)
	    {

	    }

	}
}
