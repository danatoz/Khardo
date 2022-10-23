using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace BL
{
	public class CategoryBL
	{

		public async Task<Guid> AddOrUpdateAsync(Category entity)
		{
			entity.Id = await new CategoryDal().AddOrUpdateAsync(entity);
			return entity.Id;
		}

		public Task<bool> ExistsAsync(Guid id)
		{
			return new CategoryDal().ExistsAsync(id);
		}

		public async Task<Category> GetAsync(Guid id)
		{
			return await new CategoryDal().GetAsync(id);
		}

		public async Task<List<Category>> GetAsync()
		{
			return await new CategoryDal().GetAsync();
		}

		public async Task<List<Category>> GetAsync(Expression<Func<Category, bool>> predicate)
		{
			return await new CategoryDal().GetAsync(predicate);
		}

		public async Task<List<Category>> GetAsync(Expression<Func<Category, bool>> filter = null, Func<IQueryable<Category>, IOrderedQueryable<Category>> orderBy = null, params Expression<Func<Category, object>>[] includes)
		{
			return await new CategoryDal().GetAsync(filter, orderBy, includes);
		}

		public Task<bool> DeleteHardAsync(Guid id)
		{
			return new CategoryDal().DeleteHardAsync(id);
		}


		public async Task<IEnumerable<Category>> GetParentCatalogs(Guid? parentId)
		{
			var list = new List<Category>();
			var catalog = await new CategoryBL().GetAsync();
			while (true)
			{
				var category = catalog.FirstOrDefault(item => item.Id == parentId);

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

		public async Task<string> GenerateFullUrl(Guid? categoryId)
		{
			var categories = await GetParentCatalogs(categoryId.Value);
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

		public async Task<IList<Category>> GetParentCatalogs(string aliasPath)
		{
			var list = await new CategoryBL().GetAsync(item => aliasPath.Contains(item.Alias));

			return aliasPath.Split(new string[] { "/" }, StringSplitOptions.RemoveEmptyEntries)
				.Distinct()
				.Select(alias => 
					list.FirstOrDefault(item => 
						item.Alias == alias))
				.Where(category => category != null).ToList();
		}

		public async Task<Category> GetSimpleByAliasAsync(string alias)
		{
			try
			{
				var categories = await new CategoryBL().GetAsync(item => item.Alias == alias && item.IsPublic);

				return categories.FirstOrDefault();
			}
			catch
			{

			}

			return new Category();
		}
	}
}
