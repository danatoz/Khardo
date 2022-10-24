namespace UI.Extensions
{
	public static class Extensions
	{
		//public static IServiceCollection AddAuthenticationConfig(this IServiceCollection services, ApplicationDbContext dbContext)
		//{
		//	services.AddAuthentication()
		//		.AddCookie(nameof(AuthScheme.Admin), options =>
		//		{
		//			options.LoginPath = new PathString("/Admin/Users/Login");
		//			options.AccessDeniedPath = new PathString("/Admin/Users/Login");
		//			options.ExpireTimeSpan = new TimeSpan(30, 0, 0, 0);
		//			options.Events.OnValidatePrincipal += async context =>
		//			{
		//				if (!context.Principal.Identity.IsAuthenticated)
		//				{
		//					return;
		//				}

		//				var user = dbContext.Users.FirstOrDefaultAsync(item =>
		//					item.UserName == context.Principal.Identity.Name).Result;
		//				if (user == null)
		//				{
		//					context.RejectPrincipal();
		//					await context.HttpContext.SignOutAsync(nameof(AuthScheme.Admin));
		//					return;
		//				}
		//				context.ReplacePrincipal(new ClaimsPrincipal(new CustomUserIdentity(user)));

		//			};

		//		})
		//		.AddCookie(nameof(AuthScheme.Vendor), options =>
		//		{
		//			options.LoginPath = new PathString("/Vendor/Users/Login");
		//			options.AccessDeniedPath = new PathString("/Vendor/Users/Login");
		//			options.ExpireTimeSpan = new TimeSpan(30, 0, 0, 0);
		//			options.Events.OnValidatePrincipal += async context =>
		//			{
		//				if (!context.Principal.Identity.IsAuthenticated)
		//				{
		//					return;
		//				}

		//				//ar user = dbContext.Vendors.FirstOrDefaultAsync(item =>
		//				//	item.Login == context.Principal.Identity.Name).Result;
		//				//f (user == null)
		//				//
		//				//	context.RejectPrincipal();
		//				//	await context.HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
		//				//	return;
		//				//
		//				//context.ReplacePrincipal(new ClaimsPrincipal(new CustomUserIdentity(user)));
		//			};

		//		})
		//		.AddCookie(nameof(AuthScheme.Public), options =>
		//		{
		//			options.LoginPath = new PathString("/Public/Login");
		//			options.ExpireTimeSpan = new TimeSpan(30, 0, 0, 0);

		//		});
		//	return services;
		//}
	}
}
