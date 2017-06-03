using System;
using System.Reflection;

using Nucleo.Core;
using Nucleo.Dependencies;
using Nucleo.Presentation;


namespace Nucleo.Presentation.Initialization
{
	/// <summary>
	/// Represents the default logic for initializing Presenters; this component uses the dependency resolver to inject values into properties in the Presenter that have the [Dependency] declaration, represented by <see cref="DependencyAttribute"/>.
	/// </summary>
	public class DefaultPresenterInitializer : IPresenterInitializer
	{
		/// <summary>
		/// Initializes the presenter, examining its properties and looking for the <see cref="DependencyAttribute"/> reference.
		/// </summary>
		/// <param name="Presenter">The presenter to initialize.</param>
		public void Initialize(IPresenter presenter)
		{
			var resolver = FrameworkSettings.Resolver;
			if (resolver == null)
				return;

			var props = presenter.GetType().GetProperties();

			foreach (var prop in props)
			{
				if (prop.GetCustomAttribute<DependencyAttribute>(false) != null)
				{
					var val = resolver.GetDependency(prop.PropertyType);
					if (val != null)
						prop.SetValue(presenter, val, null);
				}
			}
		}
	}
}
