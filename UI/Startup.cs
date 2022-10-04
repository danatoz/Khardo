using System;
using System.Linq;
using System.Net;
using System.Security.Claims;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using DAL;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Logging;
using Common.Enums;
using DAL.MsSqlServer;
using Microsoft.Net.Http.Headers;
using Tools.RabbitMq;


namespace UI
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }
		private ApplicationDbContext _context;
		public void ConfigureServices(IServiceCollection services)
		{
			var dbType = Configuration["Database"];
			switch (dbType)
			{
				case "MsSql":
					services.AddKhardoDbSqlServer(Configuration.GetConnectionString("MsSqlConnectionString"));
					break;
				default:
					services.AddDbContext<ApplicationDbContext>(options => 
						options.UseInMemoryDatabase(databaseName: "Default"));
					break;
			}
			services.AddMvc();
			_context = services.BuildServiceProvider().GetService<ApplicationDbContext>();
			services.AddAuthenticationConfig(_context);
			services.AddControllersWithViews().AddRazorRuntimeCompilation();
			services.AddRazorPages();
			services.AddRouting(options => options.LowercaseUrls = true);
			services.AddScoped<IRabbitMqService, RabbitMqService>();
			//services.AddTransient<IBreadCrumbDataProvider, BreadCrumbDataProvider>();
			services.AddHttpContextAccessor();
		}

		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
				app.UseDatabaseErrorPage();
			}
			else
			{
				app.UseExceptionHandler("/Home/Error");
				app.UseHsts();
			}
			app.UseHttpsRedirection();
			app.UseStaticFiles(new StaticFileOptions
			{
				OnPrepareResponse = context =>
				{
					context.Context.Response.Headers.Append(HeaderNames.CacheControl, "public, max-age=31622400");
				}
			});

			app.UseRouting();

			app.UseAuthentication();
			app.UseAuthorization();

			app.UseEndpoints(ConfigureEndPoints);
		}

		private void ConfigureEndPoints(IEndpointRouteBuilder endpoints)
		{
			endpoints.MapControllerRoute(
				name: "AdminDefaultRoute",
				pattern: "Admin/{controller=Home}/{action=Index}/{id?}",
				new { area = "Admin" });

			endpoints.MapControllerRoute(
				name: "AdminErrorRoute",
				pattern: "Admin/{controller=Error}/{code:int}",
				defaults: new { area = "Admin", action = "Index" });

			endpoints.MapControllerRoute(
				name: "VendorDefaultRoute",
				pattern: "Vendor/{controller=Home}/{action=Index}/{id?}",
				new { area = "Vendor" });

			endpoints.MapControllerRoute(
				name: "VendorErrorRoute",
				pattern: "Vendor/{controller=Error}/{code:int}",
				defaults: new { area = "Vendor", action = "Index" });

			#region Custom Constrains

			//endpoints.MapControllerRoute(
			//	name: "ProductDetails",
			//	pattern: @"{**alias}",
			//	defaults: new { area = "Public", controller = "Products", action = "Details", },
			//	constraints: new { alias = new ProductRouteConstraint() }
			//);

			//endpoints.MapControllerRoute(
			//	name: "SubCatalog",
			//	pattern: @"{**alias}",
			//	defaults: new { area = "Public", controller = "Catalogs", action = "SubCategoryList" },
			//	constraints: new { alias = new CatalogRouteConstraint() }
			//);
			#endregion

			endpoints.MapControllerRoute(
				name: "PublicDefaultRoute",
				pattern: "{controller=Home}/{action=Index}/{id?}",
				new { area = "Public" });

			endpoints.MapControllerRoute(
				name: "PublicErrorRoute",
				pattern: "{controller=Error}/{code:int}",
				defaults: new { area = "Public", action = "Index" });
		}
	}
}
