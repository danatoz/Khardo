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
				var users = new List<User>()
				{
					new User
					{
						Email = "admin@admin.ru",
						Login = "admin",
						Password = "cd8c29b8deed323fe1538cfbdb46fc2a2ea61cfd67807f0629708ea2a6e13a2919def3c837c4e7f2c8e0067568e3236827defb05c9346e476b6e954440a908a7",
						CityId = cityId,
						Role = (int)UserRole.Admin
					},
					new User()
					{
						Email = "manager@manager.ru",
						Login = "manager",
						Password = "cd8c29b8deed323fe1538cfbdb46fc2a2ea61cfd67807f0629708ea2a6e13a2919def3c837c4e7f2c8e0067568e3236827defb05c9346e476b6e954440a908a7",
						CityId = cityId,
						Role = (int)UserRole.Manager,
						MobilePhone = "8 800 555-35-35",
						LastName = "Иванов",
						FirstName = "Иван",
						MiddleName = "Иванович"
					}
				};
				context.Users.AddRange(users);
				context.SaveChanges();

				var vendors = new List<Vendor>()
				{
					new Vendor()
					{
						Email = "vendor@vendor.ru",
						Login = "vendor",
						Password = "cd8c29b8deed323fe1538cfbdb46fc2a2ea61cfd67807f0629708ea2a6e13a2919def3c837c4e7f2c8e0067568e3236827defb05c9346e476b6e954440a908a7",
						ResponsibleId = 2
					}
				};
				context.Vendors.AddRange(vendors);
				context.SaveChanges();

				var catalogs = new List<Catalog>()
				{
				    //new Catalog() { Id = 1 ,Name = "Каталог", Alias = "/catalog", IconUrl = ""},
				    new Catalog() { Id = 2 ,Name = "Шины", Alias = "shiny", IconUrl = "", ParentId = null, Active = true },
					new Catalog() { Id = 3 ,Name = "Технические жидкости", Alias = "techshidkosti", IconUrl = "", ParentId = null, Active = true  },
					new Catalog() { Id = 4 ,Name = "Масла", Alias = "maslo", IconUrl = "", ParentId = 3, Active = true  },
					new Catalog() { Id = 5 ,Name = "Масло моторное", Alias = "motornye-masla", IconUrl = "", ParentId = 4, Active = true  },
					new Catalog() { Id = 6 ,Name = "Свечи зажигания", Alias = "plug", IconUrl = "", ParentId = null, Active = true  },
					new Catalog() { Id = 7 ,Name = "Охлаждающие жидкости", Alias = "ohlashdaushieshidkosti", IconUrl = "", ParentId = 3, Active = true  },
					new Catalog() { Id = 8 ,Name = "Трансмиссионные масла", Alias = "transmissionnye-masla-i-gur", IconUrl = "", ParentId = 4, Active = true  },
					new Catalog() { Id = 9 ,Name = "Коврики", Alias = "kovriki", IconUrl = "", ParentId = null, Active = true  },
					new Catalog() { Id = 10 ,Name = "АКБ", Alias = "akkumulyatornye-batarei", IconUrl = "", ParentId = null, Active = true  },
					new Catalog() { Id = 11 ,Name = "Для кузова", Alias = "body-catalog", IconUrl = "", ParentId = null, Active = true  },
					new Catalog() { Id = 13 ,Name = "Диски", Alias = "diski", IconUrl = "", ParentId = null, Active = true  },
					new Catalog() { Id = 14 ,Name = "Автолампочки", Alias = "lamp", IconUrl = "", ParentId = null, Active = true  },
					new Catalog() { Id = 15 ,Name = "Автохимия", Alias = "ochistiteli-online", IconUrl = "", ParentId = null, Active = true  },
					new Catalog() { Id = 16 ,Name = "Смазки", Alias = "smazki-online", IconUrl = "", ParentId = null, Active = true  },
					new Catalog() { Id = 17 ,Name = "Присадки", Alias = "prisadki-online", IconUrl = "", ParentId = null, Active = true  },
					new Catalog() { Id = 18 ,Name = "Герметики", Alias = "germetiki", IconUrl = "", ParentId = null, Active = true  },
					new Catalog() { Id = 19 ,Name = "Клеи", Alias = "klei-online", IconUrl = "", ParentId = null, Active = true  },
					new Catalog() { Id = 20 ,Name = "Ароматизаторы", Alias = "smell", IconUrl = "", ParentId = null, Active = true  },
					new Catalog() { Id = 21 ,Name = "Защита картера и КПП", Alias = "katalog-motodor", IconUrl = "", ParentId = null, Active = true  },
					new Catalog() { Id = 22 ,Name = "Чехлы автомобильные", Alias = "chekhly", IconUrl = "", ParentId = null, Active = true  },
					new Catalog() { Id = 23 ,Name = "Фаркопы", Alias = "farkop", IconUrl = "", ParentId = null, Active = true  },
					new Catalog() { Id = 24 ,Name = "Системы выпуска", Alias = "lampnew", IconUrl = "", ParentId = null, Active = true  },
				};

				context.Catalogs.AddRange(catalogs);
				context.SaveChanges();

				var products = new List<Product>()
				{
					new Product()
					{
						Id = 1,
						Name = "Шина R18/215 65",
						CatalogId = 1,
						Amount = 4,
						Description = "Шина классная, резиновая",
						UrlImage = "",
						Alias = "",
						Active = true
					},
					new Product() { Id = 2, Name = "Масло моторное 5W40", CatalogId = 4, Amount = 12, Description = "Shell", UrlImage = "", Alias = "",
						Active = true },
					new Product() { Id = 3, Name = "Масло моторное 5W30", CatalogId = 4, Amount = 4, Description = "Nissan", UrlImage = "", Alias = "",
						Active = true},
					new Product() { Id = 4, Name = "Свеча зажигания", CatalogId = 5, Amount = 4, Description = "оригенал", UrlImage = "", Alias = "plug",
						Active = true},
					new Product() { Id = 5, Name = "Свеча зажигания NGK", CatalogId = 5, Amount = 20, Description = "Гарантия качества", UrlImage = "", Alias = "",
						Active = true},
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
