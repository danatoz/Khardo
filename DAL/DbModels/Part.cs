using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DbModels
{
    public class Part : IDbModel
    {
	    public int Id { get; set; }
	    public string Name { get; set; }
	    public string Alias { get; set; }
	    public string UrlImage { get; set; }
	    public string Description { get; set; }
	    public int Amount { get; set; }
	    public int CatalogId { get; set; }
		[ForeignKey("CatalogId")]
	    public Catalog Catalog { get; set; }
    }
}
