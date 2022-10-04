using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DbModels
{
	public class OrderPosition
	{
		[Key]
		[Column(TypeName = "bigint")]
		public long Id { get; set; }

		[Column(TypeName = "bigint")]
		public long OrderId { get; set; }

		[Column(TypeName = "bigint")]
		public long ProductId { get; set; }

		[ForeignKey("ProductId")]
		public Product Product { get; set; }

		[ForeignKey("OrderId")]
		public Order Order { get; set; }
	}
}
