using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Enums
{
    public enum UserRole
    {
		[Display(Name = "Разработчик")]
		Developer = 0,

		[Display(Name = "Администратор")]
		Admin = 1,

		[Display(Name = "Менеджер")]
		Manager = 2,

		[Display(Name = "Продавец")]
		Vendor = 3,

		[Display(Name = "Покупатель")]
		Customer = 4,
	}
}
