using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Entities.Base;

namespace Entities
{
	public class Product : Entity
	{
		public Guid ProductTemplateId { get; set; }

		public Guid PriceId { get; set; }

		public int Amount { get; set; }

		[Column(TypeName = "money")]
		public decimal Price { get; set; }

		public bool Active { get; set; }

		[ForeignKey("ProductTemplateId")]
		[NotMapped]
		public ProductTemplate ProductTemplate { get; set; }

		[ForeignKey("PriceId")]
		[NotMapped]
		public PriceList PriceList { get; set; }
	}
}
