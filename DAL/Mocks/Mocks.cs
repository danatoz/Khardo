using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.DbModels;
using Microsoft.AspNetCore.Identity;

namespace DAL.Mocks
{
    public static class Mocks
    {
	    public static void AddTestData(ApplicationDbContext context)
	    {
		    try
		    {
			    var testCity1 = new City()
			    {
				    Name = "Саратов"
			    };
			    var cityId = context.Cities.Add(testCity1).Entity.Id;
			    context.SaveChanges();
			    var testUser1 = new User
			    {
				    Email = "admin@admin.ru",
				    EmailConfirmed = true,
				    UserName = "admin",
					NormalizedUserName = "admin".ToUpper(),
					PasswordHash = "AQAAAAEAACcQAAAAEP1qIAwb08aQimiZcPsH6K0sT8I6lYvNUaZuO1KXUFvRZbEjml5OEE1pcHPOSDqQkA==",
					CityId = cityId,
					NormalizedEmail = "admin@admin.ru".ToUpper()
				};
			    var testRole1 = new IdentityRole("admin");
			    context.Roles.Add(testRole1);
			    context.Users.Add(testUser1);

			    context.SaveChanges();

			    var admin = context.Users.FirstOrDefault(item => item.UserName == testUser1.UserName);
			    var role = context.Roles.FirstOrDefault();
			    context.UserRoles.Add(new IdentityUserRole<string>() { RoleId = role.Id, UserId = admin.Id });
			    context.SaveChanges();

			    var catalogs = new List<Catalog>()
			    {
				    new Catalog() { Id = 1 ,Name = "Шины", Alias = "shini", IconUrl = ""},
					new Catalog() { Id = 2 ,Name = "Технические жидкости", Alias = "techshidkosti", IconUrl = "" },
				    new Catalog() { Id = 3 ,Name = "Масла", Alias = "maslo", IconUrl = "", ParentId = 2 },
				    new Catalog() { Id = 4 ,Name = "Масло моторное", Alias = "maslomotornoe", IconUrl = "", ParentId = 3 },
				    new Catalog() { Id = 5 ,Name = "Свечи зажигания", Alias = "plug", IconUrl = ""},
				    new Catalog() { Id = 6 ,Name = "Охлаждающие жидкости", Alias = "ohlashdaushieshidkosti", IconUrl = "", ParentId = 2 },
				    new Catalog() { Id = 7 ,Name = "Трансмиссионные масла", Alias = "transmissionnoemaslo", IconUrl = "", ParentId = 3 },
			    };

				context.Catalogs.AddRange(catalogs);
				context.SaveChanges();

				var products = new List<Product>()
				{
					new Product() { Id = 1, Name = "Шина R18/215 65", CatalogId = 1, Amount = 4, Description = "Шина классная, резиновая", UrlImage = "", Alias = ""},
					new Product() { Id = 2, Name = "Масло моторное 5W40", CatalogId = 4, Amount = 12, Description = "Shell", UrlImage = "", Alias = "" },
					new Product() { Id = 3, Name = "Масло моторное 5W30", CatalogId = 4, Amount = 4, Description = "Nissan", UrlImage = "", Alias = ""},
					new Product() { Id = 4, Name = "Свеча зажигания", CatalogId = 5, Amount = 4, Description = "оригенал", UrlImage = "", Alias = ""},
					new Product() { Id = 5, Name = "Свеча зажигания NGK", CatalogId = 5, Amount = 20, Description = "Гарантия качества", UrlImage = "", Alias = ""},
				};
				context.Products.AddRange(products);
				context.SaveChanges();
		    }
			catch (Exception ex)
		    {
			    Console.WriteLine(ex);
		    }

	    }
	}
}
