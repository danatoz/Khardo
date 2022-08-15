using DAL;
using DAL.Mocks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NLog.Web;

namespace UI
{
	public class Program
	{
		public static void Main(string[] args)
		{

			var host = CreateHostBuilder(args).Build();

			using (var scope = host.Services.CreateScope())
			{
				var services = scope.ServiceProvider;
				var context = services.GetRequiredService<ApplicationDbContext>();
				Mocks.AddTestData(context);
			}
			host.Run();
		}

		private static IHostBuilder CreateHostBuilder(string[] args) =>
			Host.CreateDefaultBuilder(args)
				.ConfigureWebHostDefaults(webBuilder =>
				{
					webBuilder.UseStartup<Startup>();
					webBuilder.ConfigureLogging(loggerBuilder =>
						{

						})
						.UseNLog();
				});
	}
}
