using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
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
				var categories = new List<Category>()
				{
				    //new Catalog() { Id = 1 ,Name = "Каталог", Alias = "/catalog", IconUrl = ""},
				    new Category() { Id = 2 ,Description = "", Name = "Шины", Alias = "shiny", IconUrl = "", ParentId = null, Active = true },
					new Category() { Id = 3 ,Description = "",Name = "Технические жидкости", Alias = "techshidkosti", IconUrl = "", ParentId = null, Active = true  },	   
					new Category() { Id = 4 ,Description = "",Name = "Масла", Alias = "maslo", IconUrl = "", ParentId = 3, Active = true  },
					new Category() { Id = 5 ,Description = "",Name = "Масло моторное", Alias = "motornye-masla", IconUrl = "", ParentId = 4, Active = true  },			   
					new Category() { Id = 6 ,Description = "",Name = "Свечи зажигания", Alias = "plug", IconUrl = "", ParentId = null, Active = true  },
					new Category() { Id = 7 ,Description = "",Name = "Охлаждающие жидкости", Alias = "ohlashdaushieshidkosti", IconUrl = "", ParentId = 3, Active = true  },   
					new Category() { Id = 8 ,Description = "", Name = "Трансмиссионные масла", Alias = "transmissionnye-masla-i-gur", IconUrl = "", ParentId = 4, Active = true  },
					new Category() { Id = 9 ,Description = "", Name = "Коврики", Alias = "kovriki", IconUrl = "", ParentId = null, Active = true  },
					new Category() { Id = 10 ,Description = "", Name = "АКБ", Alias = "akkumulyatornye-batarei", IconUrl = "", ParentId = null, Active = true  },
					new Category() { Id = 11 ,Description = "", Name = "Для кузова", Alias = "body-catalog", IconUrl = "", ParentId = null, Active = true  },
					new Category() { Id = 13 ,Description = "", Name = "Диски", Alias = "diski", IconUrl = "", ParentId = null, Active = true  },
					new Category() { Id = 14 ,Description = "", Name = "Автолампочки", Alias = "lamp", IconUrl = "", ParentId = null, Active = true  },
					new Category() { Id = 15 ,Description = "", Name = "Автохимия", Alias = "ochistiteli-online", IconUrl = "", ParentId = null, Active = true  },
					new Category() { Id = 16 ,Description = "", Name = "Смазки", Alias = "smazki-online", IconUrl = "", ParentId = null, Active = true  },
					new Category() { Id = 17 ,Description = "", Name = "Присадки", Alias = "prisadki-online", IconUrl = "", ParentId = null, Active = true  },
					new Category() { Id = 18 ,Description = "", Name = "Герметики", Alias = "germetiki", IconUrl = "", ParentId = null, Active = true  },
					new Category() { Id = 19 ,Description = "",Name = "Клеи", Alias = "klei-online", IconUrl = "", ParentId = null, Active = true  },
					new Category() { Id = 20 ,Description = "",Name = "Ароматизаторы", Alias = "smell", IconUrl = "", ParentId = null, Active = true  },
					new Category() { Id = 21 ,Description = "",Name = "Защита картера и КПП", Alias = "katalog-motodor", IconUrl = "", ParentId = null, Active = true  },
					new Category() { Id = 22 ,Description = "",Name = "Чехлы автомобильные", Alias = "chekhly", IconUrl = "", ParentId = null, Active = true  },
					new Category() { Id = 23 ,Description = "",Name = "Фаркопы", Alias = "farkop", IconUrl = "", ParentId = null, Active = true  },
					new Category() { Id = 24 ,Description = "",Name = "Системы выпуска", Alias = "lampnew", IconUrl = "", ParentId = null, Active = true  },
				};

				context.Categories.AddRange(categories);
				context.SaveChanges();
				var countries = new List<Country>()
				{
					new Country()
					{
						Id = 1,
						Name = "Япония"
					},
					new Country()
					{
						Id = 2,
						Name = "Германия"
					}
				};

				context.Countries.AddRangeAsync(countries);
				context.SaveChangesAsync();

				var manufactures = new List<Manufacturer>()
				{
					new Manufacturer()
					{
						Id = 1,
						Name = "Nissan",
						UrlLogo = "",
						CountryId = 1
					},
					new Manufacturer()
					{
						Id = 2,
						Name = "Volkswagen",
						UrlLogo = "",
						CountryId = 2
					}

				};
				context.Manufacturers.AddRangeAsync(manufactures);
				context.SaveChangesAsync();

				var productTemplate = new List<ProductTemplate>()
				{
					new ProductTemplate()
					{
						VendorCode = "4300xs-R18",
						Name = "Шина R18/215 65",
						CategoryId = 2,
						Description = "Шина классная, резиновая",
						Photos = new List<ProductPhoto>()
						{
							new ProductPhoto()
							{
								Id = 1,
								ProductTemplateId = "4300xs-R18",
								UrlImage = ""
							}
						},
						ManufacturerId = 1,
						Active = true
					},
				};
				context.ProductTemplates.AddRange(productTemplate);
				context.SaveChanges();

				var products = new List<Product>()
				{
					new Product()
					{
						Id = 1,
						Amount = 4,
						Price = 23000,
						//VendorId = 1,
						VendorCode = "4300xs-R18",
						Active = true,
						Alias = "",
					}
				};

				context.Products.AddRange(products);
				context.SaveChangesAsync();
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex);
			}

		}
	}
}
