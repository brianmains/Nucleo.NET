using System;
using System.Collections.Generic;
using System.Text;

namespace Nucleo
{
	public class Identifier
	{
		private object _identifier = null;



		#region " Constructors "

		private Identifier(object identifier)
		{
			_identifier = identifier;
		}

		#endregion



		#region " Methods "

		public static Identifier Create(Int16 key)
		{
			return new Identifier(key);
		}

		public static Identifier Create(Int32 key)
		{
			return new Identifier(key);
		}

		public static Identifier Create(Int64 key)
		{
			return new Identifier(key);
		}

		public static Identifier Create(Guid key)
		{
			if (key == null)
				throw new ArgumentNullException("key");

			return new Identifier(key);
		}

		public object Get()
		{
			return _identifier;
		}

		public T Get<T>()
		{
			return (T)_identifier;
		}

		#endregion
	}
}
