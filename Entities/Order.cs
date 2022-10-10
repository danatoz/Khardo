using Entities.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    public class Order : Entity
	{
		public DateTime CreationDate { get; set; }

		public string UserId { get; set; }

		[ForeignKey("UserId")]
		public User Customer { get; set; }

		public List<OrderPosition> OrderPositions { get; set; }
	}
}
