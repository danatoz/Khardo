using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using Entities.Base.Interfaces;

namespace Entities.Base
{
	public abstract class Entity<TKey> : IEntity<TKey>
	{
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public TKey Id { get; set; } = default!;

		protected Entity() { }

		protected Entity(TKey Id) => this.Id = Id;
	}

	public abstract class Entity : Entity<int>, IEntity
	{
		protected Entity() { }

		protected Entity(int Id) : base(Id) { }
	}
}
