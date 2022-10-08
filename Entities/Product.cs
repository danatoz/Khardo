using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
	public class Product
	{
		[Key]
		[Column(TypeName = "bigint")]
		public long Id { get; set; }

		public string? VendorCode { get; set; }

		public string? VendorId { get; set; }

		public string Alias { get; set; }

		public int Amount { get; set; }

		public decimal Price { get; set; }

		public bool Active { get; set; }

		[ForeignKey("VendorCode")]
		public ProductTemplate? ProductTemplate { get; set; }

		[ForeignKey("VendorId")] 
		public User? Vendor { get; set; }
	}
}
