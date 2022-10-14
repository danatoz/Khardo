using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DAL
{
	public abstract class BaseDal<TDbContext, TEntity, TPrimaryKey >
	where TDbContext : DbContext, new()
	where TEntity : class
	{
		protected TDbContext _context;
		public BaseDal()
		{
			
		}

		protected BaseDal(TDbContext context)
		{
			_context = context;
		}

		public virtual async Task<TEntity> GetAsync(TPrimaryKey id)
		{
			var data = GetContext();
			try
			{
				return await data.Set<TEntity>().FindAsync(id);
			}
			catch (Exception e)
			{
				throw;
			}
			finally
			{
				await this.DisposeContextAsync(data);
			}
		}

		public virtual async Task<List<TEntity>> GetAsync()
		{
			var data = GetContext();
			try
			{
				return await data.Set<TEntity>().ToListAsync();
			}
			catch (Exception e)
			{
				throw;
			}
		}

		public virtual async Task<List<TEntity>> GetAsync(Expression<Func<TEntity, bool>> predicate)
		{
			var data = GetContext();
			try
			{
				return await data.Set<TEntity>().Where(predicate).ToListAsync();
			}
			catch (Exception e)
			{
				throw;
			}
		}

		public virtual async Task<List<TEntity>> GetAsync(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, params Expression<Func<TEntity, object>>[] includes)
		{
			var data = GetContext();
			try
			{
				IQueryable<TEntity> query = data.Set<TEntity>();

				query = includes.Aggregate(query, (current, include) => current.Include(include));

				if (filter != null)
					query = query.Where(filter);

				if (orderBy != null)
					query = orderBy(query);

				return await query.ToListAsync();
			}
			catch (Exception e)
			{
				throw;
			}
		}

		public virtual async Task<TPrimaryKey > AddOrUpdateAsync(TEntity entity)
		{
			var data = GetContext();
			try
			{
				var exists = await ExistsAsync(GetIdByDbObject(entity));
				switch (exists)
				{
					case true:
						data.Set<TEntity>().Update(entity).State = EntityState.Modified;
						break;
					default:
						await data.Set<TEntity>().AddAsync(entity);
						break;
				}

				await data.SaveChangesAsync();
				return GetIdByDbObject(entity);
			}
			catch (Exception e)
			{
				throw;
			}
			finally
			{
				await this.DisposeContextAsync(data);
			}
		}

		public virtual async Task AddOrUpdateAsync(IList<TEntity> entities)
		{
			entities?.Select(async e => await AddOrUpdateAsync(e));
		}

		public virtual async Task<bool> DeleteHardAsync(TPrimaryKey  id)
		{
			var data = GetContext();
			var result = false;
			try
			{

				var entity = await data.Set<TEntity>().FindAsync();
				if (entity != null)
					data.Set<TEntity>().Remove(entity);

				await data.SaveChangesAsync();
				result = true;
			}
			catch (Exception e)
			{
				return result;
			}	
			return result;
		}

		public virtual Task<bool> ExistsAsync(TPrimaryKey  id)
		{
			return ExistsAsync(GetCheckDbObjectIdExpression(id));
		}

		internal virtual async Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> predicate)
		{
			var data = GetContext();
			try
			{
				return await data.Set<TEntity>().Where(predicate).AnyAsync();
			}
			catch (Exception ex)
			{
				throw;
			}
			finally
			{
				await DisposeContextAsync(data);
			}
		}

		protected MemberInfo GetDbObjectIdMember()
		{
			return (GetIdByDbObjectExpression().Body as MemberExpression)?.Member;
		}

		protected Expression<Func<TEntity, bool>> GetCheckDbObjectIdExpression(TPrimaryKey  objectId)
		{
			var p = Expression.Parameter(typeof(TEntity));
			return Expression.Lambda<Func<TEntity, bool>>(Expression.Equal(
					Expression.MakeMemberAccess(p, GetDbObjectIdMember()),
					Expression.Property(Expression.Constant(new { Id = objectId }), "Id")),
				p);
		}

		protected abstract Expression<Func<TEntity, TPrimaryKey >> GetIdByDbObjectExpression();

		protected TPrimaryKey  GetIdByDbObject(TEntity entity)
		{
			return GetIdByDbObjectExpression().Compile()(entity);
		}

		protected TDbContext GetContext() => _context ?? new TDbContext();

		protected async Task<bool> DisposeContextAsync(TDbContext context, [CallerMemberName] string name = "")
		{
			if (ReferenceEquals(context, _context)) return false;
			await context.DisposeAsync();
			return true;
		}
	}
}
