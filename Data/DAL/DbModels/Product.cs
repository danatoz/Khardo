namespace DAL.DbModels
{
    public class Product : Entity
    {
	    public string Name { get; set; }
	    public string VendorCode { get; set; }
	    public string Alias { get; set; }
	    public string UrlImage { get; set; }
	    public string Description { get; set; }
	    public int Amount { get; set; }
	    public decimal Price { get; set; }
	    public int CatalogId { get; set; }
	    public int? ManufacturerId { get; set; }
	    public int ManufacturerType { get; set; }
	    public int VendorId { get; set; }
	    public bool Active { get; set; }
		[ForeignKey("CatalogId")]
	    public Catalog Catalog { get; set; }
	    [ForeignKey("ManufacturerId")]
	    public Manufacturer Manufacturer { get; set; }
		[ForeignKey("VendorId")]
	    public Vendor Vendor { get; set; }
    }
}
