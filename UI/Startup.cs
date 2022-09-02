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
using DAL.DbModels;
using DAL.Mocks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Logging;
using Common.Enums;
using UI.Constraints.RouteConstraints;
using UI.Models;
using UI.Tools;

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
			//services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer("Server=localhost;Database=Khardo;Trusted_Connection=True;MultipleActiveResultSets=true"));
			services.AddDbContext<ApplicationDbContext>(options => options.UseInMemoryDatabase(databaseName: "Default"));
			services.AddMvc();
			//services.AddIdentity<User, IdentityRole>(options =>
			//{
			//	options.User.RequireUniqueEmail = false;
			//})
			//	.AddEntityFrameworkStores<ApplicationDbContext>()
			//	.AddDefaultUI()
			//	.AddDefaultTokenProviders();

			services.AddAuthentication()
				.AddCookie(nameof(AuthScheme.Admin), options =>
				 {
					 options.LoginPath = new PathString("/Admin/Users/Login");
					 options.AccessDeniedPath = new PathString("/Admin/Users/Login");
					 options.ExpireTimeSpan = new TimeSpan(30, 0, 0, 0);
					 options.Events.OnValidatePrincipal += async context =>
					 {
						 if (!context.Principal.Identity.IsAuthenticated)
						 {
							 return;
						 }

						 var user = _context.Users.FirstOrDefaultAsync(item =>
							 item.Login == context.Principal.Identity.Name).Result;
						 if (user == null)
						 {
							 context.RejectPrincipal();
							 await context.HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
							 return;
						 }
						 context.ReplacePrincipal(new ClaimsPrincipal(new CustomUserIdentity(user)));

					 };

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

			services.AddTransient<IBreadCrumbDataProvider, BreadCrumbDataProvider>();
			_context = services.BuildServiceProvider().GetService<ApplicationDbContext>();
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

			#region Custom Constrains

			endpoints.MapControllerRoute(
				name: "ProductDetails",
				pattern: @"{**alias}",
				defaults: new { area = "Public", controller = "Products", action = "Details", },
				constraints: new { alias = new ProductRouteConstraint() }
			);

			endpoints.MapControllerRoute(
				name: "SubCatalog",
				pattern: @"{**alias}",
				defaults: new { area = "Public", controller = "Catalogs", action = "SubCategoryList" },
				constraints: new { alias = new CatalogRouteConstraint() }
			);
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
