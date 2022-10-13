using Entities.Base;

namespace Entities
{
	public class Country : Entity
	{
		public string Name { get; set; }

		public string NormalizeName { get; set; }
	}
}
