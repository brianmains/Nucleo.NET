using System;
using System.Collections.Generic;
using System.Text;

namespace Nucleo.EventArguments
{
	/// <summary>
	/// Represents the event arguments for redirection services.
	/// </summary>
	public class RedirectEventArgs
	{
		private bool _cancelRedirect = false;
		private string _navigateUrl = null;



		#region " Properties "

		/// <summary>
		/// Gets or sets whether to cancel the redirection.
		/// </summary>
		public bool CancelRedirect
		{
			get { return _cancelRedirect; }
			set { _cancelRedirect = value; }
		}

		/// <summary>
		/// Gets or sets the URL to navigate to.
		/// </summary>
		public string NavigateUrl
		{
			get { return _navigateUrl; }
			set { _navigateUrl = value; }
		}

		#endregion



		#region " Constructors "

		public RedirectEventArgs(string navigateUrl)
			: this(navigateUrl, false) { }

		public RedirectEventArgs(string navigateUrl, bool cancelRedirect)
		{
			_navigateUrl = navigateUrl;
			_cancelRedirect = cancelRedirect;
		}

		#endregion
	}


	public delegate void RedirectEventHandler(object sender, RedirectEventArgs e);
}
