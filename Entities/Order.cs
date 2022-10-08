using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    public class Order
    {
	    [Key]
	    [Column(TypeName = "bigint")]
	    public long Id { get; set; }

	    public DateTime CreationDate { get; set; }

		public string? CustomerId { get; set; }

		[ForeignKey("CustomerId")]
		[NotMapped]
		public Customer? Customer { get; set; }

		public List<OrderPosition>? OrderPositions { get; set; }
	}
}
