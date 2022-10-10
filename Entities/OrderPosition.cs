using Entities.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
	public class OrderPosition : Entity
	{
		public Guid OrderId { get; set; }

		public Guid ProductId { get; set; }

		[ForeignKey("ProductId")]
		public Product Product { get; set; }

		[ForeignKey("OrderId")]
		public Order Order { get; set; }
	}
}
