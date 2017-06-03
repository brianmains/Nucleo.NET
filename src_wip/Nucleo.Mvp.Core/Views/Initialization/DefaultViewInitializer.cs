using System;
using System.Reflection;

using Nucleo.Core;
using Nucleo.Dependencies;
using Nucleo.Presentation;
using Nucleo.Views;
using Nucleo.Views.Initialization;


namespace Nucleo.Views.Initialization
{
	/// <summary>
	/// Represents the default logic for initializing views; this component uses the dependency resolver to inject values into properties in the view that have the [Dependency] declaration, represented by <see cref="DependencyAttribute"/>.
	/// </summary>
	public class DefaultViewInitializer : IViewInitializer
	{
		/// <summary>
		/// Initializes the view, examining its properties and looking for the <see cref="DependencyAttribute"/> reference.
		/// </summary>
		/// <param name="view">The view to initialize.</param>
		public void Initialize(Nucleo.Views.IView view)
		{
			var resolver = FrameworkSettings.Resolver;
			if (resolver == null)
				return;

			var props = view.GetType().GetProperties();

			foreach (var prop in props)
			{
				if (prop.GetCustomAttribute<DependencyAttribute>(false) != null)
				{
					var val = resolver.GetDependency(prop.PropertyType);
					if (val != null)
						prop.SetValue(view, val, null);
				}
			}
		}
	}
}
