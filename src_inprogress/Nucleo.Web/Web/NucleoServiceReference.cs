using System;
using System.Web.UI;


namespace Nucleo.Web
{
	/// <summary>
	/// Represents the service reference options for web services.
	/// </summary>
	public class NucleoServiceReference : ServiceReference
	{
		private ServiceReferenceIncludeOptions _inclusionOptions = ServiceReferenceIncludeOptions.Any;



		#region " Properties "

		/// <summary>
		/// Gets or sets the inclusion options for the service reference.
		/// </summary>
		public ServiceReferenceIncludeOptions InclusionOptions
		{
			get { return _inclusionOptions; }
			set { _inclusionOptions = value; }
		}

		#endregion



		#region " Constructors "

		/// <summary>
		/// Creates an empty reference.
		/// </summary>
		public NucleoServiceReference()
			: base() { }

		/// <summary>
		/// Creates a reference with a given service path.
		/// </summary>
		/// <param name="path">The path to the service.</param>
		public NucleoServiceReference(string path)
			: base(path) { }

		#endregion



		#region " Methods "

		/// <summary>
		/// Converts this reference into a newly constructed base reference.
		/// </summary>
		/// <returns>The base reference.</returns>
		public ServiceReference ToServiceReference()
		{
			ServiceReference reference = new ServiceReference(this.Path);
			reference.InlineScript = this.InlineScript;

			return reference;
		}

		#endregion
	}
}
