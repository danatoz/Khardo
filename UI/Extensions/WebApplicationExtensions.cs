using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.MsSqlServer;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace UI.Extensions
{
	public static class WebApplicationExtensions
	{
		public static async Task InitializeDb(this WebApplication webApplication)
		{
			var conf = webApplication.Configuration;
			await using var serviceScope = webApplication.Services.CreateAsyncScope();
			var services = serviceScope.ServiceProvider;
			var dbInitializer = services.GetRequiredService<DbInitializer>();
			await dbInitializer.InitializeAsync(RemoveBefore: conf.GetValue("DbRemoveBefore", false),
				InitializeTestData: conf.GetValue("DbInitializeTestData", false));
		}
	}
}
