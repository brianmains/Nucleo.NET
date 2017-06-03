using System;
using System.Collections.Generic;
using System.Text;

namespace Nucleo.Web
{
	/// <summary>
	/// Represents the ID of the element.
	/// </summary>
	public class ElementIdentifier
	{
		private string _id = null;



		#region " Properties "

		/// <summary>
		/// Gets the ID of the client-side element.
		/// </summary>
		public string ID
		{
			get { return _id; }
		}

		#endregion



		#region " Constructors "

		/// <summary>
		/// Creates the element identifier with the client-side ID.
		/// </summary>
		/// <param name="id">The ID of the element.</param>
		public ElementIdentifier(string id)
		{
			_id = id;
		}

		#endregion
	}
}
