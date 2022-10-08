using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using NLog;
using NLog.Web;

namespace UI
{
	public class Program2
	{
		public static void Main(string[] args)
		{
			var logger = NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();

			try
			{
				var host = CreateHostBuilder(args).Build();
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
