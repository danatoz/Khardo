using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Enums;
using Entities.Base;

namespace Entities
{
	public class PriceList : Entity
	{
		public string UserId { get; set; }

		public DateTime CreationDate { get; set; }

		public PriceStatus PriceStatus { get; set; }

		public bool IsPublicate { get; set; }

		[ForeignKey("UserId")]
		public User Vendor { get; set; }
	}
}
