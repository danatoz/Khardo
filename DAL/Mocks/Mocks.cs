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
	    //public static List<User> Users = new List<User>();

	    public static void AddTestData(ApplicationDbContext context)
	    {
		    var testUser1 = new User
		    {
			    Email = "admin@admin.ru",
			    EmailConfirmed = true,
				UserName = "admin",
			    PasswordHash = "123"
			};
		    var testRole1 = new IdentityRole("admin");
		    //context.Roles.Add(testRole1);
		    context.Users.Add(testUser1);

		    context.SaveChanges();

		   // var admin = context.Users.FirstOrDefault(item => item.UserName == "admin");
		    //var role = context.Roles.FirstOrDefault();
		   // context.UserRoles.Add(new IdentityUserRole<string>() { RoleId = role.Id, UserId = admin.Id });

		    //context.SaveChanges();
	    }
	}
}
