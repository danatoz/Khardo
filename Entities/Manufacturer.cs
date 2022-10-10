using System.ComponentModel.DataAnnotations.Schema;
using Entities.Base;

namespace Entities
{
    public class Manufacturer : Entity
    {
	    public string Name { get; set; }

	    public string UrlLogo { get; set; }

	    public Guid? CountryId { get; set; }

		[ForeignKey("CountryId")]
		public Country Country { get; set; }

	}
}
