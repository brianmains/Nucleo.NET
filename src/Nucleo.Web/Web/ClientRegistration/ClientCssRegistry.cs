using System;
using System.Collections.Generic;
using System.Web.UI;

using Nucleo.Reflection;
using Nucleo.Web.ClientRegistration.Css;


namespace Nucleo.Web.ClientRegistration
{
	/// <summary>
	/// Represents a registry for css loaded for a class, by pulling the information from the class level.
	/// </summary>
	public class ClientCssRegistry
	{
		private CssReferenceRequestDetailsCollection _css = null;



		#region " Properties "

		/// <summary>
		/// Gets the scripts associated with the registry.
		/// </summary>
		public CssReferenceRequestDetailsCollection Css
		{
			get
			{
				if (_css == null)
					_css = new CssReferenceRequestDetailsCollection();
				return _css;
			}
		}

		#endregion



		#region " Constructors "

		protected ClientCssRegistry() { }

		#endregion



		#region " Methods "

		/// <summary>
		/// Creates a registry object by looking for css references at the class level.
		/// </summary>
		/// <param name="target">The target to look for css references for.</param>
		/// <returns>The registry with all of the CSS references within the class.</returns>
		public static ClientCssRegistry CreateFor(object target)
		{
			if (target == null)
				throw new ArgumentNullException("target");

			ClientCssRegistry registry = new ClientCssRegistry();

			if (target is IWebCssMetadataCssRegistryImplementation)
				registry.Css.AddRange(new WebCssMetadataCssRegistrar().GetPrimaryDetails(target));
			else if (target is IClientAttributeCssRegistryImplementation)
				registry.Css.AddRange(new ClientAttributeCssRegistrar().GetPrimaryDetails(target));
			else if (target is ISelfTypeCssRegistryImplementation)
				registry.Css.AddRange(new SelfTypeCssRegistrar().GetPrimaryDetails(target));
			else
			{
				registry.Css.AddRange(new ClientAttributeCssRegistrar().GetPrimaryDetails(target));
				registry.Css.AddRange(new WebCssMetadataCssRegistrar().GetPrimaryDetails(target));
			}

			return registry;
		}

		#endregion
	}
}
