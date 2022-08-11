using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.DbModels;
using Microsoft.AspNetCore.Identity;

namespace DAL.Mocks
{
    public class Mocks
    {
	    public List<User> Users { get; set; }
	    public Task Initialize()
	    {
			Users.Add(new User()
			{
				Id = "1",
				Email = "admin@admin.ru",
				EmailConfirmed = true,
				//PasswordHash = 
			});
			return new Task(() => {});
	    }
    }
}
