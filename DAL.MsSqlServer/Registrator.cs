using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DAL.MsSqlServer
{
	public static class Registrator
	{
		public static IServiceCollection AddKhardoDbSqlServer(this IServiceCollection services, string ConnectionString)
		{
			services.AddDbContext<ApplicationDbContext>(opt => opt
				.UseSqlServer(
					ConnectionString,
					o => o.MigrationsAssembly(typeof(Registrator).Assembly.FullName)));

			return services;
		}
	}
}