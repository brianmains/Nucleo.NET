using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nucleo.Configuration
{
	public static class NameTypeElementExtensions
	{
		#region " Methods "

		/// <summary>
		/// Loads the type specified in the name/type pairing.
		/// </summary>
		/// <typeparam name="T">The type of object that the type parameter instantiates.</typeparam>
		/// <param name="element">The element.</param>
		/// <returns>The type to instantiate.</returns>
		public static T LoadType<T>(this NameTypeElement element)
		{
			return ActivatorLoader.LoadType<T>(element);
		}

		#endregion
	}
}
