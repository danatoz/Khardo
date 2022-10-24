using Entities.Base;
using Microsoft.EntityFrameworkCore;

namespace Entities
{
	[Index(nameof(NormalizedVendorCode), nameof(Name))]
	public class ProductTemplate : Entity
	{
		public string VendorCode { get; set; }

		public string NormalizedVendorCode { get; set; }

		public string Name { get; set; }

		public Guid? CategoryId { get; set; }

		public Guid ManufacturerId { get; set; }

		public string Description { get; set; }

		public int ManufacturerType { get; set; }

		public string Alias { get; set; }

		public bool Active { get; set; }

		[ForeignKey("ManufacturerId")]
		public Manufacturer Manufacturer { get; set; }

		[ForeignKey("CategoryId")]
		public Category Category { get; set; }

		public List<ProductPhoto> Photos { get; set; }
	}
}
