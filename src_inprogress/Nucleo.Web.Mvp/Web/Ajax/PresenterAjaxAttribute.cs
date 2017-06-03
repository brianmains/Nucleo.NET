using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nucleo.Web.Ajax
{
	/// <summary>
	/// Represents the AJAX settings for presenters.  Ignored on other types of classes.
	/// </summary>
	[AttributeUsage(AttributeTargets.Class)]
	public class PresenterAjaxAttribute : Attribute
	{
		private bool _enableWebMethods;



		#region " Properties "

		/// <summary>
		/// Gets or sets whether web methods are enabled.
		/// </summary>
		public bool EnableWebMethods
		{
			get { return _enableWebMethods; }
			set { _enableWebMethods = value; }
		}

		#endregion
	}
}
