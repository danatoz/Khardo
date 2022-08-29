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
    public class CatalogsBL
    {
	    public readonly ApplicationDbContext _context;
	    public CatalogsBL(ApplicationDbContext context)
	    {
		    _context = context;
	    }

	    public CatalogsBL()
	    {
	    }
	    public async Task<IEnumerable<Catalog>> GetParentCatalogs(int parentId)
	    {
		    var list = new List<Catalog>();
		    var catalog = _context.Catalogs;
		    while (true)
		    {
			    var category = await catalog.FirstOrDefaultAsync(item => item.Id == parentId);

				if (category != null)
			    {
				    list.Insert(0, category);
				    if (category.ParentId != null)
					    parentId = category.ParentId.Value;
				    else
					    break;
			    }
			    else
				    break;
		    }

		    return list;
	    }

		public async Task<string> GenerateFullUrl(int categoryId)
		{
			var categories = await GetParentCatalogs(categoryId);
			var builder = new StringBuilder();
			foreach (var alias in categories.Select(item => item.Alias))
			{
				if (builder.Length == 0)
					builder.Append(alias);
				else
					builder.AppendFormat("/{0}", alias);
			}

			return builder.ToString();
		}

		public async Task<IList<Catalog>> GetParentCatalogs(string aliasPath)
		{
			var list = await _context.Catalogs.Where(item => aliasPath.Contains(item.Alias)).ToListAsync();

			return aliasPath.Split(new string[] {"/"}, StringSplitOptions.RemoveEmptyEntries).Distinct().Select(alias => list.FirstOrDefault(item => item.Alias == alias)).Where(category => category != null).ToList();
		}

		public async Task<Catalog> GetSimpleByAliasAsync(string alias)
		{
			try
			{
				return await _context.Catalogs.FirstOrDefaultAsync(item => item.Alias == alias && item.IsPublic);
			}
			catch
			{

			}

			return new Catalog();
		}
	}
}
