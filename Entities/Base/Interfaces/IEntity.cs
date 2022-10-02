using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Base.Interfaces
{
	public interface IEntity<TKey>
	{
		TKey Id { get; set; }
	}

	public interface IEntity : IEntity<int> { }
}
