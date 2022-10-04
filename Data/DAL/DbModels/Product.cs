using System.ComponentModel.DataAnnotations;

namespace DAL.DbModels
{
	public class Product
	{
		[Key]
		[Column(TypeName = "bigint")]
		public long Id { get; set; }

		public string VendorCode { get; set; }

		public int VendorId { get; set; }

		public string Alias { get; set; }

		public int Amount { get; set; }

		public decimal Price { get; set; }

		public bool Active { get; set; }

		[ForeignKey("VendorCode")]
		public ProductTemplate ProductTemplate { get; set; }

		[ForeignKey("VendorId")] 
		public Vendor Vendor { get; set; }
	}
}
