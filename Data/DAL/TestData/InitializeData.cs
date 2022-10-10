using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Microsoft.AspNetCore.Identity;
using Common.Enums;

namespace DAL.TestData
{
    public static class InitializeData
    {
        public static IEnumerable<Category> CategoryInitialize()
        {
            return new List<Category>()
                {
				    //new Catalog() { Id = 1 ,Name = "Каталог", Alias = "/catalog", IconUrl = ""},
				    new Category() { 
					    //Id = 2 ,
					    Description = "", Name = "Шины", Alias = "shiny", IconUrl = "", ParentId = null, Active = true },
                    new Category() { 
						//Id = 3 ,
						Description = "",Name = "Технические жидкости", Alias = "techshidkosti", IconUrl = "", ParentId = null, Active = true  },
                    new Category() { 
						//Id = 4 ,
						Description = "",Name = "Масла", Alias = "maslo", IconUrl = "", ParentId = null, Active = true  },
                    new Category() { 
						//Id = 5 ,
						Description = "",Name = "Масло моторное", Alias = "motornye-masla", IconUrl = "", ParentId = null, Active = true  },
                    new Category() { 
						//Id = 6 ,
						Description = "",Name = "Свечи зажигания", Alias = "plug", IconUrl = "", ParentId = null, Active = true  },
                    new Category() { 
						//Id = 7 ,
						Description = "",Name = "Охлаждающие жидкости", Alias = "ohlashdaushieshidkosti", IconUrl = "", ParentId = null, Active = true  },
                    new Category() { 
						//Id = 8 ,
						Description = "", Name = "Трансмиссионные масла", Alias = "transmissionnye-masla-i-gur", IconUrl = "", ParentId = null, Active = true  },
                    new Category() { 
						//Id = 9 ,
						Description = "", Name = "Коврики", Alias = "kovriki", IconUrl = "", ParentId = null, Active = true  },
                    new Category() { 
						//Id = 10 ,
						Description = "", Name = "АКБ", Alias = "akkumulyatornye-batarei", IconUrl = "", ParentId = null, Active = true  },
                    new Category() { 
						//Id = 11 ,
						Description = "", Name = "Для кузова", Alias = "body-catalog", IconUrl = "", ParentId = null, Active = true  },
                    new Category() { 
						//Id = 13 ,
						Description = "", Name = "Диски", Alias = "diski", IconUrl = "", ParentId = null, Active = true  },
                    new Category() { 
						//Id = 14 ,
						Description = "", Name = "Автолампочки", Alias = "lamp", IconUrl = "", ParentId = null, Active = true  },
                    new Category() { 
						//Id = 15 ,
						Description = "", Name = "Автохимия", Alias = "ochistiteli-online", IconUrl = "", ParentId = null, Active = true  },
                    new Category() { 
						//Id = 16 ,
						Description = "", Name = "Смазки", Alias = "smazki-online", IconUrl = "", ParentId = null, Active = true  },
                    new Category() { 
						//Id = 17 ,
						Description = "", Name = "Присадки", Alias = "prisadki-online", IconUrl = "", ParentId = null, Active = true  },
                    new Category() { 
						//Id = 18 ,
						Description = "", Name = "Герметики", Alias = "germetiki", IconUrl = "", ParentId = null, Active = true  },
                    new Category() { 
						//Id = 19 ,
						Description = "",Name = "Клеи", Alias = "klei-online", IconUrl = "", ParentId = null, Active = true  },
                    new Category() { 
						//Id = 20 ,
						Description = "",Name = "Ароматизаторы", Alias = "smell", IconUrl = "", ParentId = null, Active = true  },
                    new Category() { 
						//Id = 21 ,
						Description = "",Name = "Защита картера и КПП", Alias = "katalog-motodor", IconUrl = "", ParentId = null, Active = true  },
                    new Category() { 
						//Id = 22 ,
						Description = "",Name = "Чехлы автомобильные", Alias = "chekhly", IconUrl = "", ParentId = null, Active = true  },
                    new Category() { 
						//Id = 23 ,
						Description = "",Name = "Фаркопы", Alias = "farkop", IconUrl = "", ParentId = null, Active = true  },
                    new Category() { 
						//Id = 24 ,
						Description = "",Name = "Системы выпуска", Alias = "lampnew", IconUrl = "", ParentId = null, Active = true  },
                };
        }

        public static IEnumerable<Country> CountryInitialize()
        {
            return new List<Country>()
            {
                new Country()
                {
                    Name = "Япония"
                },
                new Country()
                {
                    Name = "Германия"
                }
            };
        }

        public static List<User> UsersInitialize()
        {
            try
            {
                return new List<User>()
                {
                    new User
                    {
                        Email = "admin@admin.ru",
                        NormalizedEmail = "admin@admin.ru",
                        UserName = "admin",
                        NormalizedUserName = "admin".ToUpper(),
                        PasswordHash = "AQAAAAEAACcQAAAAENQf6ryosecLchMJDOBS4Mwgl5LWnOipFk+GjsT+4blS1eotrwSVsWZzN+Q99VfAUg==",
                        EmailConfirmed = true,
                        PhoneNumberConfirmed = false,
                        LockoutEnabled = false
					},
                    new User()
                    {
                        Email = "manager@manager.ru",
                        NormalizedEmail = "manager@manager.ru",
                        UserName = "manager",
                        NormalizedUserName = "manager".ToUpper(),
                        PasswordHash = "AQAAAAEAACcQAAAAENQf6ryosecLchMJDOBS4Mwgl5LWnOipFk+GjsT+4blS1eotrwSVsWZzN+Q99VfAUg==",
                        EmailConfirmed = true,
                        PhoneNumberConfirmed = false,
                        LockoutEnabled = false
					},
                    new User()
                    {
                        Email = "vendor@vendor.ru",
                        NormalizedEmail = "vendor@vendor.ru",
                        UserName = "vendor",
                        NormalizedUserName = "vendor".ToUpper(),
                        PasswordHash = "AQAAAAEAACcQAAAAENQf6ryosecLchMJDOBS4Mwgl5LWnOipFk+GjsT+4blS1eotrwSVsWZzN+Q99VfAUg==",
                        NameOrganization = "ООО \"Понтал++\"",
                        EmailConfirmed = true,
                        PhoneNumberConfirmed = false,
                        LockoutEnabled = false
					},
                    new User()
                    {
                        Email = "customer@customer.ru",
                        NormalizedEmail = "customer@customer.ru",
                        UserName = "customer",
                        NormalizedUserName = "customer".ToUpper(),
                        PasswordHash = "AQAAAAEAACcQAAAAENQf6ryosecLchMJDOBS4Mwgl5LWnOipFk+GjsT+4blS1eotrwSVsWZzN+Q99VfAUg==",
                        EmailConfirmed = true,
                        PhoneNumberConfirmed = false,
                        LockoutEnabled = false
					}
                };
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public static List<IdentityRole> RoleInitialize()
        {
	        return new List<IdentityRole>()
	        {
		        new IdentityRole()
		        {
			        Name = "admin",
			        NormalizedName = "ADMIN"
		        },		        
		        new IdentityRole()
		        {
			        Name = "manager",
			        NormalizedName = "MANAGER"
		        },		        
		        new IdentityRole()
		        {
			        Name = "customer",
			        NormalizedName = "CUSTOMER"
		        },		        
		        new IdentityRole()
		        {
			        Name = "vendor",
			        NormalizedName = "VENDOR"
		        },
	        };
        }
    }
}
