using System;
using System.Linq;
using System.Net;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using DAL;
using DAL.DbModels;
using DAL.Mocks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Logging;
using UI.Enums;

namespace UI
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		public void ConfigureServices(IServiceCollection services)
		{
			services.AddDbContext<ApplicationDbContext>(options => options.UseInMemoryDatabase(databaseName: "Default"));
			services.AddMvc();
			//services.AddDefaultIdentity<User>(options => options.SignIn.RequireConfirmedAccount = false)
			//	.AddEntityFrameworkStores<ApplicationDbContext>();
			services.AddIdentity<User, IdentityRole>(options =>
			{
				options.User.RequireUniqueEmail = false;
			})
				.AddEntityFrameworkStores<ApplicationDbContext>()
				.AddDefaultUI()
				.AddDefaultTokenProviders();

			services.AddAuthentication()
				.AddCookie(nameof(AuthScheme.Admin), options =>
				 {
					 options.LoginPath = new PathString("/Admin/Login");
					 options.ExpireTimeSpan = new TimeSpan(30, 0, 0, 0);

				 })
				.AddCookie(nameof(AuthScheme.Client), options =>
				{
					options.LoginPath = new PathString("/Client/Login");
					options.ExpireTimeSpan = new TimeSpan(30, 0, 0, 0);

				})
				.AddCookie(nameof(AuthScheme.Public), options =>
				{
					options.LoginPath = new PathString("/Public/Login");
					options.ExpireTimeSpan = new TimeSpan(30, 0, 0, 0);

				});

			services.AddControllersWithViews().AddRazorRuntimeCompilation();
			services.AddRazorPages();
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
			app.UseStaticFiles();

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
				name: "ClientDefaultRoute",
				pattern: "Client/{controller=Home}/{action=Index}/{id?}",
				new { area = "Client" });

			endpoints.MapControllerRoute(
				name: "ClientErrorRoute",
				pattern: "Client/{controller=Error}/{code:int}",
				defaults: new { area = "Client", action = "Index" });

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
