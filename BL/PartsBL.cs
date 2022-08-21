using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DAL.DbModels;
using Microsoft.EntityFrameworkCore;

namespace BL
{
    public class PartsBL
    {
	    private readonly ApplicationDbContext _context;
	    public PartsBL(ApplicationDbContext context)
	    {
		    _context = context;
	    }

	    public PartsBL()
	    {
		    
	    }
	    public async Task<IEnumerable<Product>> GetSimpleByAliasAsync(string alias)
	    {
		    return await _context.Products.Where(item => item.Alias == alias && item.Catalog != null).ToListAsync();
		}
    }
}
