using System;
using DAL;
using DAL.Mocks;
using DAL.TestData;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NLog;
using NLog.Web;

namespace UI
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var logger = NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();

			try
			{
				var host = CreateHostBuilder(args).Build();

				using (var scope = host.Services.CreateScope())
				{
					var services = scope.ServiceProvider;
					var context = services.GetRequiredService<ApplicationDbContext>();
					var usersContext = services.GetRequiredService<UserDbContext>();
					Mocks.AddTestData(context);
					UsersTestData.SetTestData(usersContext);
				}
				host.Run();
			}
			catch (Exception ex)
			{
				logger.Error(ex, "App run was unsuccessful");
			}
			finally
			{
				LogManager.Shutdown();
			}
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
