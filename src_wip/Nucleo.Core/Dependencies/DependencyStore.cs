using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nucleo.Dependencies
{
	public static class DependencyStore
	{
		private static IDependencyResolver _resolver = null;


		public static IDependencyResolver Resolver
		{
			get
			{
				return _resolver;
			}
			set
			{
				if (_resolver == value)
					return;

				lock (typeof(DependencyStore))
				{
					if (_resolver != value)
						_resolver = value;
				}
			}
		}

	}
}
