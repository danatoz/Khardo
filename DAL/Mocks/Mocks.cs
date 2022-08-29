using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.DbModels;
using Microsoft.AspNetCore.Identity;
using Common.Enums;

namespace DAL.Mocks
{
    public static class Mocks
    {
	    public static void AddTestData(ApplicationDbContext context)
	    {
		    try
		    {
			    var cityId = context.Cities.Add(new City()
			    {
				    Name = "Саратов"
			    }).Entity.Id;
			    context.SaveChanges();
			    var testUser1 = new User
			    {
				    Email = "admin@admin.ru",
				    //EmailConfirmed = true,
				    Login = "admin",
					//NormalizedUserName = "admin".ToUpper(),
					Password = "AQAAAAEAACcQAAAAEP1qIAwb08aQimiZcPsH6K0sT8I6lYvNUaZuO1KXUFvRZbEjml5OEE1pcHPOSDqQkA==",
					CityId = cityId,
					Role = (int)UserRole.Admin
					//NormalizedEmail = "admin@admin.ru".ToUpper()
				};
			    //var testRole1 = new IdentityRole("admin");
			    //context.Roles.Add(testRole1);
			    context.Users.Add(testUser1);

			    context.SaveChanges();

			    //var admin = context.Users.FirstOrDefault(item => item.UserName == testUser1.UserName);
			    //var role = context.Roles.FirstOrDefault();
			    //context.UserRoles.Add(new IdentityUserRole<string>() { RoleId = role.Id, UserId = admin.Id });
			    //context.SaveChanges();

			    var catalogs = new List<Catalog>()
			    {
				    new Catalog() { Id = 1 ,Name = "Каталог", Alias = "/catalog", IconUrl = ""},
				    new Catalog() { Id = 2 ,Name = "Шины", Alias = "shiny", IconUrl = "", ParentId = 1 },
					new Catalog() { Id = 3 ,Name = "Технические жидкости", Alias = "techshidkosti", IconUrl = "", ParentId = 1 },
				    new Catalog() { Id = 4 ,Name = "Масла", Alias = "maslo", IconUrl = "", ParentId = 3 },
				    new Catalog() { Id = 5 ,Name = "Масло моторное", Alias = "motornye-masla", IconUrl = "", ParentId = 4 },
				    new Catalog() { Id = 6 ,Name = "Свечи зажигания", Alias = "plug", IconUrl = "", ParentId = 1 },
				    new Catalog() { Id = 7 ,Name = "Охлаждающие жидкости", Alias = "ohlashdaushieshidkosti", IconUrl = "", ParentId = 3 },
				    new Catalog() { Id = 8 ,Name = "Трансмиссионные масла", Alias = "transmissionnye-masla-i-gur", IconUrl = "", ParentId = 4 },
				    new Catalog() { Id = 9 ,Name = "Коврики", Alias = "kovriki", IconUrl = "", ParentId = 1 },
				    new Catalog() { Id = 10 ,Name = "АКБ", Alias = "akkumulyatornye-batarei", IconUrl = "", ParentId = 1 },
				    new Catalog() { Id = 11 ,Name = "Для кузова", Alias = "body-catalog", IconUrl = "", ParentId = 1 },
				    new Catalog() { Id = 13 ,Name = "Диски", Alias = "diski", IconUrl = "", ParentId = 1 },
				    new Catalog() { Id = 14 ,Name = "Автолампочки", Alias = "lamp", IconUrl = "", ParentId = 1 },
				    new Catalog() { Id = 15 ,Name = "Автохимия", Alias = "ochistiteli-online", IconUrl = "", ParentId = 1 },
				    new Catalog() { Id = 16 ,Name = "Смазки", Alias = "smazki-online", IconUrl = "", ParentId = 1 },
				    new Catalog() { Id = 17 ,Name = "Присадки", Alias = "prisadki-online", IconUrl = "", ParentId = 1 },
				    new Catalog() { Id = 18 ,Name = "Герметики", Alias = "germetiki", IconUrl = "", ParentId = 1 },
				    new Catalog() { Id = 19 ,Name = "Клеи", Alias = "klei-online", IconUrl = "", ParentId = 1 },
				    new Catalog() { Id = 20 ,Name = "Ароматизаторы", Alias = "smell", IconUrl = "", ParentId = 1 },
				    new Catalog() { Id = 21 ,Name = "Защита картера и КПП", Alias = "katalog-motodor", IconUrl = "", ParentId = 1 },
				    new Catalog() { Id = 22 ,Name = "Чехлы автомобильные", Alias = "chekhly", IconUrl = "", ParentId = 1 },
				    new Catalog() { Id = 23 ,Name = "Фаркопы", Alias = "farkop", IconUrl = "", ParentId = 1 },
				    new Catalog() { Id = 24 ,Name = "Системы выпуска", Alias = "lampnew", IconUrl = "", ParentId = 1 },
			    };

				context.Catalogs.AddRange(catalogs);
				context.SaveChanges();

				var products = new List<Product>()
				{
					new Product() { Id = 1, Name = "Шина R18/215 65", CatalogId = 1, Amount = 4, Description = "Шина классная, резиновая", UrlImage = "", Alias = ""},
					new Product() { Id = 2, Name = "Масло моторное 5W40", CatalogId = 4, Amount = 12, Description = "Shell", UrlImage = "", Alias = "" },
					new Product() { Id = 3, Name = "Масло моторное 5W30", CatalogId = 4, Amount = 4, Description = "Nissan", UrlImage = "", Alias = ""},
					new Product() { Id = 4, Name = "Свеча зажигания", CatalogId = 5, Amount = 4, Description = "оригенал", UrlImage = "", Alias = "plug"},
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
