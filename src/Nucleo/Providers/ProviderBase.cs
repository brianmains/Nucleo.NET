using System;
using System.Collections.Generic;
using System.Text;

namespace Nucleo.Providers
{
	/// <summary>
	/// Represents the base class for a provider.
	/// </summary>
	public class ProviderBase : System.Configuration.Provider.ProviderBase
	{
		private string _applicationName;



		#region " Properties "

		/// <summary>
		/// Gets or sets the name of the application (used to vary the data within the provider).
		/// </summary>
		public string ApplicationName
		{
			get { return _applicationName; }
			set { _applicationName = value; }
		}

		#endregion
	}
}
