using DAL.MsSqlServer;
using DAL;
using EnvDTE;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Tools.RabbitMq;
using Microsoft.Net.Http.Headers;
using Microsoft.AspNetCore.Routing;
using UI.Services;

var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;
var services = builder.Services;

services.AddControllersWithViews()
	.AddRazorRuntimeCompilation();

#region Services

var dbType = configuration["Database"];
switch (dbType)
{
	case "MsSql":
		services.AddKhardoDbSqlServer(configuration.GetConnectionString("MsSqlConnectionString"));
		break;
	default:
		services.AddDbContext<AppDbContext>(options =>
			options.UseInMemoryDatabase(databaseName: "Default"));
		break;
}
services.AddMvc();

services.AddIdentity<User, IdentityRole>()
	.AddEntityFrameworkStores<AppDbContext>();

services.AddControllersWithViews().AddRazorRuntimeCompilation();
services.AddRazorPages();
services.AddRouting(options => options.LowercaseUrls = true);
services.AddTransient<DbInitializer>();
services.AddScoped<IRabbitMqService, RabbitMqService>();
services.AddTransient<IBreadCrumbDataProvider, BreadCrumbDataProvider>();
services.AddHttpContextAccessor();
services.AddDatabaseDeveloperPageExceptionFilter();
services.AddHostedService<RabbitMqListener>();

#endregion

var app = builder.Build();
await app.InitializeDb();
if (app.Environment.IsDevelopment())
{
	app.UseDeveloperExceptionPage();
	app.UseMigrationsEndPoint();
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

await app.RunAsync();


void ConfigureEndPoints(IEndpointRouteBuilder endpoints)
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
	//	constraints: new { alias = new CategoryRouteConstraint() }
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