using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
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
		public Product? Product { get; set; }

		[ForeignKey("OrderId")]
		public Order? Order { get; set; }
	}
}
