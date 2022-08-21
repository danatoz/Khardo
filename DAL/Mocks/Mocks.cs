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
			}
			catch (Exception ex)
		    {
			    Console.WriteLine(ex);
		    }

	    }
	}
}
