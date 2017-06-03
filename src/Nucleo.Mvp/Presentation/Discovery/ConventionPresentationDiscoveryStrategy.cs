using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

using Nucleo.Views;


namespace Nucleo.Presentation.Discovery
{
	/// <summary>
	/// Represents the discovery strategy by convention, using the same namespace structure as the view.
	/// </summary>
	public class ConventionPresentationDiscoveryStrategy : IPresentationDiscoveryStrategy
	{
		#region " Properties "

		/// <summary>
		/// Gets the segment within the namespace for the presenter.  This allows easier customization of the process for presenter replacement.
		/// </summary>
		public virtual string PresenterNamespaceSegment
		{
			get { return "Presentation"; }
		}

		/// <summary>
		/// Gets the segment within the namespace for the view.  This allows easier customization of the process for finding views.
		/// </summary>
		public virtual string ViewNamespaceSegment
		{
			get { return "Views"; }
		}

		#endregion



		#region " Methods "

		private Type FindType(IView view)
		{
			var type = view.GetType();
			if (type.FullName.Contains("ASP."))
				type = type.BaseType;

			return type;
		}

		/// <summary>
		/// Finds a presenter type using the discovery options.
		/// </summary>
		/// <param name="options">The options to use.</param>
		/// <returns>The found type, or null if not found.</returns>
		public virtual Type FindPresenterType(DiscoveryOptions options)
		{
			var type = FindType(options.View);

			string presenterName = type.FullName;

			if (presenterName.Contains(this.ViewNamespaceSegment))
				presenterName = type.FullName.Replace("." + this.ViewNamespaceSegment + ".", "." + this.PresenterNamespaceSegment + ".");
			if (presenterName.EndsWith("View"))
				presenterName = presenterName.Substring(0, presenterName.Length - 4);
			presenterName += "Presenter";

			return FindPresenterTypeInAppDomain(presenterName, options);
		}

		/// <summary>
		/// Finds a presenter within a specific application domain.
		/// </summary>
		/// <param name="options">The options to use for discovery.</param>
		protected virtual Type FindPresenterTypeInAppDomain(string presenterType, DiscoveryOptions options)
		{
			var assemblies = AppDomain.CurrentDomain.GetAssemblies().Where(i => !i.FullName.StartsWith("mscorlib") && !i.FullName.StartsWith("System") && !i.FullName.StartsWith("Microsoft"));

			foreach (Assembly a in assemblies)
			{
				var type = a.GetTypes().FirstOrDefault(i => i.FullName == presenterType);
				if (type != null)
					return type;
			}

			return null;
		}

		#endregion
	}
}
