using System.ComponentModel.DataAnnotations;

namespace DAL.DbModels
{
    public class Order
    {
	    [Key]
	    [Column(TypeName = "bigint")]
	    public long Id { get; set; }

	    public DateTime CreationDate { get; set; }

	    public int CustomerId { get; set; }

		[ForeignKey("CustomerId")]
	    public Customer Customer { get; set; }

	    public List<OrderPosition> OrderPositions { get; set; }
	}
}
