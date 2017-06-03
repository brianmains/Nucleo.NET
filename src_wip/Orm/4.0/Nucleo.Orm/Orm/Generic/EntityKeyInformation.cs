using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nucleo.Orm.Generic
{
	/// <summary>
	/// Represents the information about the key for an entity.
	/// </summary>
	public class EntityKeyInformation
	{
		/// <summary>
		/// Gets or sets the name of the entity.
		/// </summary>
		public string EntityName
		{
			get;
			set;
		}

		/// <summary>
		/// Gets or sets the type of entity.
		/// </summary>
		public Type EntityType
		{
			get;
			set;
		}

		public string KeyName
		{
			get;
			set;
		}

		/// <summary>
		/// Gets or sets the key value.
		/// </summary>
		public object KeyValue
		{
			get;
			set;
		}
	}
}
