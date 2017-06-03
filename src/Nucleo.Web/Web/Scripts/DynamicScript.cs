using System;
using System.Web.UI;


namespace Nucleo.Web.Scripts
{
	public class DynamicScript
	{
		private string _name = null;
		private string _path = null;



		#region " Properties "

		/// <summary>
		/// Gets or sets the name of the dynamic script.
		/// </summary>
		public string Name
		{
			get { return _name; }
			set { _name = value; }
		}

		/// <summary>
		/// Gets or sets the path of the dynamic script.
		/// </summary>
		[UrlProperty("*.js")]
		public string Path
		{
			get { return _path; }
			set { _path = value; }
		}

		#endregion
	}
}
