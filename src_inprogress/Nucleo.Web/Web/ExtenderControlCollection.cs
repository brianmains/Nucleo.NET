using System;
using System.Collections.Generic;
using System.Web.UI;

using Nucleo.Collections;


namespace Nucleo.Web
{
	/// <summary>
	/// Represents a collection of extender controls.
	/// </summary>
	public class ExtenderControlCollection : SimpleCollection<IExtenderControl>
	{
		#region " Constructors "

		/// <summary>
		/// Creates an empty collection of extenders.
		/// </summary>
		public ExtenderControlCollection() { }

		/// <summary>
		/// Creates a collection of extenders.
		/// </summary>
		/// <param name="extenders">The collection of extenders to append.</param>
		public ExtenderControlCollection(IEnumerable<IExtenderControl> extenders)
		{
			foreach (IExtenderControl extender in extenders)
				this.Add(extender);
		}

		#endregion
	}
}
